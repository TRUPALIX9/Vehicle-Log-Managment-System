using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Windows.Forms;
using VLMS.Class;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VLMS.User_Controls
{
    public partial class UpdateControl : UserControl
    {

        #region Global Variables
        private const string bucketName = "aivid-vlms-anpr-det";
        private readonly IAmazonS3 s3Client;

        Dictionary<string, string> clientDirectory = new Dictionary<string, string>();
        Dictionary<string, string> awsDirectory = new Dictionary<string, string>();
        Dictionary<string, (string, string)> versionDictionary = new Dictionary<string, (string, string)>();
        List<string> availableUpdates = new List<string>();

        #endregion

        #region Initialization and On_Load
        public UpdateControl()
        {
            InitializeComponent();
            s3Client = new AmazonS3Client(RegionEndpoint.APSouth1);
        }

        private void UpdateControl_Load( object sender, EventArgs e )
        {
            CheckForUpdate();
            //  PopulateComboBox("trupal-ix", "VLMS/", RegionEndpoint.APSouth1); // Call the function with your parameters
        }
        #endregion


        #region Helpers 

        private void AddIfNotExsists( string key, string value, Dictionary<string, string> dict )
        {
            if (!dict.ContainsKey(key))
            {
                dict.Add(key, value);
            }
            else
            {
                dict[key] = value;
            }
        }
        public static bool Compare( string clientVersion, string awsS3Version )
        {
            // Split version strings into arrays of integers
            var awsVer = new Version(awsS3Version);
            var clientVer = new Version(clientVersion);

            var result = awsVer.CompareTo(clientVer);
            if (result > 0)
                return true;
            ///AWS Version is higher 
            //  else if (result < 0)
            //      return true;
            ///Client Version is highet 
            else
                return false;

        }
        private List<string> GetNonMatchingKeys( Dictionary<string, string> dict1, Dictionary<string, string> dict2 )
        {
            List<string> nonMatchingKeys = new List<string>();

            string labelText = string.Empty;
            foreach (var kvp in dict1)
            {
                // Construct the string
                labelText += $"{kvp.Key}:\n";
                labelText += $"   Current Version: {kvp.Value}\n";
                labelText += $"   Available Version: {dict2[kvp.Key]}\n\n"; // 
                if (dict2.TryGetValue(kvp.Key, out var value2))
                {
                    if (!string.Equals(kvp.Value, value2))
                    {
                        nonMatchingKeys.Add(kvp.Key);
                    }
                }
                else
                {
                    nonMatchingKeys.Add(kvp.Key);
                }
            }
            lbl_processTitle.Text = labelText;
            // Check for keys in dict2 that are not in dict1
            foreach (var kvp in dict2)
            {
                if (!dict1.ContainsKey(kvp.Key))
                {
                    nonMatchingKeys.Add(kvp.Key);
                }
            }

            return nonMatchingKeys;
        }
        #endregion

        #region Load Config and GetVersions 

        private void LoadConfigJson()
        {
            try
            {
                string jsonFilePath = Path.Combine(Properties.Settings.Default.baseVlmsPath, "config.json"); // Replace with your JSON file path
                if (File.Exists(jsonFilePath))
                {
                    string jsonData = File.ReadAllText(jsonFilePath);
                    //  richTextBox1.Text = jsonData;
                    DataModel dataModel = System.Text.Json.JsonSerializer.Deserialize<DataModel>(jsonData);
                    versionDictionary.Add("nextjs_anpr", (dataModel.nextjs_anpr, dataModel.nextjs_anpr));
                    versionDictionary.Add("aividVlms", (dataModel.aividVlms, dataModel.aividVlms));
                    AddIfNotExsists("nextjs_anpr", dataModel.nextjs_anpr, clientDirectory);
                    AddIfNotExsists("aividVlms", dataModel.aividVlms, clientDirectory);
                }
                else
                {
                    MessageBox.Show("JSON file not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private async Task GetLatestVersionsFromS3(string version)
        {
            try
            {
                string nextjsKey = Global.portalExtensoin;
                string aividVlmsKey = Global.botExtensoin;
                var getObjectTaggingRequestNextjs = new GetObjectTaggingRequest
                {
                    BucketName = bucketName,
                    Key = "VLMS/" + version +"/"+ nextjsKey + ".zip"
                };
                var getObjectTaggingRequestAividVlms = new GetObjectTaggingRequest
                {
                    BucketName = bucketName,
                    Key = "VLMS/" + version + "/" + aividVlmsKey + ".zip"
                };
                var getObjectTaggingRequestNextjsResponse = await s3Client.GetObjectTaggingAsync(getObjectTaggingRequestNextjs);
                var getObjectTaggingRequestAividVlmsResponse = await s3Client.GetObjectTaggingAsync(getObjectTaggingRequestAividVlms);
                // Print the entire response
                //  richTextBox1.Text += ($"Response: {JsonConvert.SerializeObject(getObjectTaggingResponse, Formatting.Indented)}");
                awsDirectory.Clear();
                AddIfNotExsists(nextjsKey, getObjectTaggingRequestNextjsResponse.Tagging[0].Value, awsDirectory);
                AddIfNotExsists(aividVlmsKey, getObjectTaggingRequestAividVlmsResponse.Tagging[0].Value, awsDirectory);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        #endregion

        #region Update Ui Function  
        #endregion

        #region checkForUpdate Funtion  
        private void CheckForUpdate()
        {
            //Load Client side Config.Json in Directory
            LoadConfigJson();
            PopulateComboBox(); // Call the function with your parameters

            // Wait for both tasks to complete
            // await Task.WhenAll(GetLatestVersionFromS3("nextjs_anpr"), GetLatestVersionFromS3("aividVlms"));
            //  ShowDictionaryInMessageBox(clientDirectory);
            // ShowDictionaryInMessageBox(awsDirectory);
            // Extract the keys which versions doesnt match
            //availableUpdates = GetNonMatchingKeys(clientDirectory, awsDirectory);
            // enable update buttons;
            // btn_Update.Enabled = availableUpdates.Count > 0;
            // Display the non-matching keys in the RichTextBox or any other control

        }
        #endregion
        static void ShowDictionaryInMessageBox( Dictionary<string, string> dictionary )
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var kvp in dictionary)
            {
                stringBuilder.AppendLine($"{kvp.Key}: {kvp.Value}");
            }

            string message = stringBuilder.ToString();
            MessageBox.Show(message, "Dictionary Content", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void LogME( string message )
        {
            if (kryptonRichTextBox1.InvokeRequired)
            {
                kryptonRichTextBox1.Invoke((MethodInvoker)delegate
                {
                    LogME(message);
                });
            }
            else
            {
                kryptonRichTextBox1.Text += Environment.NewLine + message + Environment.NewLine;
            }
        }

        private void ShowMessageInRichTextBox( string message )
        {
            if (kryptonRichTextBox1.InvokeRequired)
            {
                kryptonRichTextBox1.Invoke(new Action(() => kryptonRichTextBox1.AppendText(message + "\n")));
            }
            else
            {
                kryptonRichTextBox1.AppendText(message + "\n");
            }
        }
        private void btn_Update_Click( object sender, EventArgs e )
        {
            UpdateToThisVersion(comboBox1.Text);
            /*
            foreach (var kvp in availableUpdates)
            {
                btn_Update.Enabled = false;
                btn_Update.Text = " Donwloading...";
                LogME("Starting Process for and stopping service:   " + kvp);
                ServiceManager.StopExistingService(kvp == "nextjs_anpr" ? "aividPortal" : "aividVLMSBot");
                ServiceManager.WaitForServiceToStart(kvp == "nextjs_anpr" ? "aividPortal" : "aividVLMSBot", System.ServiceProcess.ServiceControllerStatus.Stopped);
                Task.Run(async () =>
                {
                    // Execute the loop body asynchronously
                    if (await UpdateKeyObjectZip(kvp))
                    {
                        // Update UI components using Invoke
                        this.Invoke((MethodInvoker)delegate
                        {
                            ServiceManager.StartExistingService(kvp == "nextjs_anpr" ? "aividPortal" : "aividVLMSBot");
                            ServiceManager.WaitForServiceToStart(kvp, System.ServiceProcess.ServiceControllerStatus.Running);
                            LogME("Completed Process for and Starting service :  " + kvp);
                            btn_Update.Text = "Update";
                        });
                    }
                    else
                    {
                        // Update UI components using Invoke
                        this.Invoke((MethodInvoker)delegate
                        {
                            LogME("UpdateKeyObjectZip failed for " + kvp);
                        });
                    }
                });
            }
            */
        }
           private async Task DownloadAndExtractZipFromS3( string bucketName, string objectKey, string destinationPath )
        {
            using (var client = new AmazonS3Client())
            {
                var request = new GetObjectRequest
                {
                    BucketName = bucketName,
                    Key = objectKey
                };

                using (var response = await client.GetObjectAsync(request))
                {
                    // Create a temporary file to download the zip
                    string tempZipFilePath = Path.GetTempFileName();
                    LogME(tempZipFilePath);
                    using (var fileStream = File.Create(tempZipFilePath))
                    {
                        await response.ResponseStream.CopyToAsync(fileStream);
                    }

                    // Extract the contents of the zip file to the destination path in parallel
                    using (var archive = ZipFile.OpenRead(tempZipFilePath))
                    {
                        int totalEntries = archive.Entries.Count;
                        int processedEntries = 0;
                        foreach (var entry in archive.Entries)
                        {
                            // Combine the destination path with the entry's relative path
                            string entryDestinationPath = Path.Combine(destinationPath, entry.FullName);

                            // If the entry is a directory, create it
                            if (entry.FullName.EndsWith("/"))
                            {
                                Directory.CreateDirectory(entryDestinationPath);
                            }
                            else
                            {
                                // Ensure the directory structure for the entry exists
                                Directory.CreateDirectory(Path.GetDirectoryName(entryDestinationPath));

                                // Extract the entry to the destination path
                                entry.ExtractToFile(entryDestinationPath, true);
                            }
                            processedEntries++;
                            // Calculate progress percentage
                            int progressPercentage = (int)((processedEntries * 100) / totalEntries);

                            // Update the progress bar
                            progressBar.Invoke((MethodInvoker)delegate
                            {
                                progressBar.Value = progressPercentage;
                            });
                        }
                    }
                    // Cleanup: delete the temporary zip file
                    File.Delete(tempZipFilePath);
                }
            }
        }
        private async Task<bool> UpdateKeyObjectZip( string version,string key )
        {
            try
            {
                string destinationPath = Properties.Settings.Default.baseVlmsPath;
                string keySourcePath = Path.Combine(Properties.Settings.Default.baseVlmsPath, key);
                LogME(keySourcePath + "------>" + keySourcePath + "1");
                Directory.Move(keySourcePath, keySourcePath + "1");
                LogME("Starting Unziiping in " + destinationPath + "...........");
                await Task.Run(async () =>
                {

                    await DownloadAndExtractZipFromS3(bucketName, key, destinationPath);
                    //await UpdateManager.UnzipS3ObjectAsync(bucketName, key, destinationPath);
                });
                LogME(key + " unzipped successfully!");
                DeleteFile(keySourcePath + "1");
                LogME(key + $" Deleted! : {keySourcePath + "1"}" + DeleteFile(keySourcePath + "1").ToString());
                return true;
            }
            catch (Exception ex)
            {
                LogME("Error in UpdateKeyObjectZip: " + ex.Message);
                return false;
            }
        }
        static bool DeleteFile( string filePath )
        {
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                    return true;
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Error deleting the file: {ex.Message}");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private async void PopulateComboBox()
        {
            var listObjectsRequest = new ListObjectsV2Request
            {
                BucketName = bucketName,
                Prefix = "VLMS"
            };

            ListObjectsV2Response response;
            try
            {
                response = await s3Client.ListObjectsV2Async(listObjectsRequest);
            }
            catch (AmazonS3Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string mainVersion = UpdateManager.GetValue("mainVersion");
            var objectKeys = new List<string>();
            foreach (var obj in response.S3Objects)
            {
                // Add object key (removing prefix) to the ComboBox
                var keyWithoutPrefix = obj.Key.Replace("VLMS/", "");
                var parts = keyWithoutPrefix.Split('/');
                if (parts.Length >= 2 && !objectKeys.Contains(parts[0])  )
                {
                    if(mainVersion != null && string.Compare(parts[0], mainVersion) > 0)
                    {
                        objectKeys.Add(parts[0]); // Add the first folder name (version number) to the HashSet
                    }
                }
            }
            btn_Update.Enabled= objectKeys.Count > 0;
            comboBox1.DataSource = objectKeys;
        }

        private async void UpdateToThisVersion (string version)
        {
          await  GetLatestVersionsFromS3(version);
       //     GetNonMatchingKeys();
//
        }
        private void btn_uninstall_Click( object sender, EventArgs e )
        {
         
        }

        private void comboBox1_SelectedIndexChanged( object sender, EventArgs e )
        {
            
        }
    }
}
