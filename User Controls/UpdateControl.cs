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
        private static readonly string bucketName = Global.updateBucketName;
        // Created on first use: the AWS SDK resolves credentials when the client is built,
        // and this control is created at startup even on machines without AWS credentials.
        private IAmazonS3? s3Client;

        Dictionary<string, string> clientDirectory = new Dictionary<string, string>();
        Dictionary<string, string> awsDirectory = new Dictionary<string, string>();
        Dictionary<string, (string, string)> versionDictionary = new Dictionary<string, (string, string)>();
        List<string> availableUpdates = new List<string>();

        #endregion

        #region Initialization and On_Load
        public UpdateControl()
        {
            InitializeComponent();
        }

        private void UpdateControl_Load( object sender, EventArgs e )
        {
            CheckForUpdate();
        }
        #endregion


        #region Helpers

        private IAmazonS3 GetS3Client()
        {
            if (s3Client == null)
            {
                s3Client = new AmazonS3Client(RegionEndpoint.GetBySystemName(Global.updateRegion));
            }
            return s3Client;
        }

        // Release objects are laid out as <prefix>/<version>/<component>.zip
        private static string ObjectKeyFor( string version, string key )
        {
            return $"{Global.updatePrefix}/{version}/{key}.zip";
        }

        private static string ServiceNameFor( string key )
        {
            return key == Global.portalExtensoin ? Global.portalServiceName : Global.botServiceName;
        }

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
            // True when the S3 version is newer than the client version.
            // Version-based, so 1.10.0 sorts after 1.9.0; folders that are not versions are ignored.
            if (!Version.TryParse(awsS3Version, out var awsVer) || !Version.TryParse(clientVersion, out var clientVer))
            {
                return false;
            }
            return awsVer.CompareTo(clientVer) > 0;
        }
        private List<string> GetNonMatchingKeys(   )
        {
            List<string> nonMatchingKeys = new List<string>();

            Dictionary<string, string> dict1 = clientDirectory;
            Dictionary<string, string> dict2 = awsDirectory;
            string labelText = string.Empty;


            foreach (var kvp in dict1)
            {
                bool found = dict2.TryGetValue(kvp.Key, out var value2);
                labelText += $"{kvp.Key}:\n";
                labelText += $"   Current Version: {kvp.Value}\n";
                labelText += $"   Available Version: {(found ? value2 : "not found")}\n\n";
                if (!found || !string.Equals(kvp.Value, value2))
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
                string jsonFilePath = Path.Combine(Properties.Settings.Default.baseVlmsPath, "config.json");
                if (File.Exists(jsonFilePath))
                {
                    string jsonData = File.ReadAllText(jsonFilePath);
                    DataModel dataModel = System.Text.Json.JsonSerializer.Deserialize<DataModel>(jsonData);
                    versionDictionary[Global.portalExtensoin] = (dataModel.nextjs_anpr, dataModel.nextjs_anpr);
                    versionDictionary[Global.botExtensoin] = (dataModel.gatelogBot, dataModel.gatelogBot);
                    AddIfNotExsists(Global.portalExtensoin, dataModel.nextjs_anpr, clientDirectory);
                    AddIfNotExsists(Global.botExtensoin, dataModel.gatelogBot, clientDirectory);
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
        private async Task<bool> GetLatestVersionsFromS3( string version )
        {
            try
            {
                awsDirectory.Clear();
                foreach (string key in new[] { Global.portalExtensoin, Global.botExtensoin })
                {
                    var getObjectTaggingRequest = new GetObjectTaggingRequest
                    {
                        BucketName = bucketName,
                        Key = ObjectKeyFor(version, key)
                    };
                    var response = await GetS3Client().GetObjectTaggingAsync(getObjectTaggingRequest);
                    if (response.Tagging.Count > 0)
                    {
                        AddIfNotExsists(key, response.Tagging[0].Value, awsDirectory);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                LogME($"Could not read component versions for release {version}: {ex.Message}");
                return false;
            }
        }

        #endregion

        #region checkForUpdate Funtion
        private void CheckForUpdate()
        {
            //Load Client side Config.Json in Directory
            LoadConfigJson();
            PopulateComboBox();
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
                kryptonRichTextBox1.AppendText($"{DateTime.Now:dd-MM-yyyy HH:mm:ss} : {message}{Environment.NewLine}");
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
        }
           private async Task DownloadAndExtractZipFromS3(  string objectKey )
        {
            var request = new GetObjectRequest
            {
                BucketName = bucketName,
                Key = objectKey
            };
            string destinationPath = Properties.Settings.Default.baseVlmsPath;
            using (var response = await GetS3Client().GetObjectAsync(request))
            {
                // Create a temporary file to download the zip
                string tempZipFilePath = Path.GetTempFileName();
                LogME($"Downloading {objectKey} to {tempZipFilePath}");
                using (var fileStream = File.Create(tempZipFilePath))
                {
                    await response.ResponseStream.CopyToAsync(fileStream);
                }

                // Extract the contents of the zip file over the install folder
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
                        int progressPercentage = totalEntries == 0 ? 100 : (int)((processedEntries * 100) / totalEntries);

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

                   // await DownloadAndExtractZipFromS3(bucketName, key, destinationPath);
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
            if (string.IsNullOrWhiteSpace(bucketName))
            {
                btn_Update.Enabled = false;
                lbl_processTitle.Text = "Update server not configured.";
                LogME("Set GATELOG_UPDATE_BUCKET (and GATELOG_UPDATE_REGION) to check for updates.");
                return;
            }
            lbl_processTitle.Text = "Checking for updates...";
            try
            {
                var listObjectsRequest = new ListObjectsV2Request
                {
                    BucketName = bucketName,
                    Prefix = Global.updatePrefix + "/"
                };
                ListObjectsV2Response response = await GetS3Client().ListObjectsV2Async(listObjectsRequest);
                string mainVersion = UpdateManager.GetValue("mainVersion");
                var objectKeys = new List<string>();
                foreach (var obj in response.S3Objects)
                {
                    // Keep the version folder name from <prefix>/<version>/<component>.zip
                    var keyWithoutPrefix = obj.Key.Substring(listObjectsRequest.Prefix.Length);
                    var parts = keyWithoutPrefix.Split('/');
                    if (parts.Length >= 2 && !objectKeys.Contains(parts[0]))
                    {
                        if (mainVersion != null && Compare(mainVersion, parts[0]))
                        {
                            objectKeys.Add(parts[0]);
                        }
                    }
                }
                // Newest release first
                objectKeys.Sort(( a, b ) => Compare(b, a) ? -1 : (Compare(a, b) ? 1 : 0));
                btn_Update.Enabled = objectKeys.Count > 0;
                comboBox1.DataSource = objectKeys;
                if (objectKeys.Count == 0)
                {
                    lbl_processTitle.Text = "No newer release found.";
                    LogME($"Installed release {mainVersion} is the latest.");
                }
            }
            catch (Exception ex)
            {
                btn_Update.Enabled = false;
                lbl_processTitle.Text = "Update server unavailable.";
                LogME($"Update server unavailable: {ex.Message}");
            }
        }

        private async void UpdateToThisVersion (string version)
        {
            if (string.IsNullOrEmpty(version))
            {
                return;
            }
            btn_Update.Enabled = false;
            try
            {
                if (!await GetLatestVersionsFromS3(version))
                {
                    return;
                }
                List<string> avialableUpdates = GetNonMatchingKeys();
                foreach (string key in avialableUpdates)
                {
                    // Stop the service first so its files can be overwritten, and always restart it
                    string serviceName = ServiceNameFor(key);
                    LogME($"Stopping {serviceName} and downloading {key} from release {version} ...");
                    ServiceManager.StopExistingService(serviceName);
                    try
                    {
                        await DownloadAndExtractZipFromS3(ObjectKeyFor(version, key));
                        awsDirectory.TryGetValue(key, out var newVersion);
                        if (newVersion != null)
                        {
                            UpdateManager.SetValue(key, newVersion);
                        }
                        LogME($"{key} updated to {newVersion}");
                    }
                    finally
                    {
                        ServiceManager.StartExistingService(serviceName);
                    }
                }
                UpdateManager.SetValue("mainVersion", version);
                LogME($"Update to release {version} complete.");
            }
            catch (Exception ex)
            {
                LogME($"Update failed: {ex.Message}");
            }
            finally
            {
                btn_Update.Enabled = true;
            }
        }
        private void btn_uninstall_Click( object sender, EventArgs e )
        {
            MessageBox.Show(
                "Uninstall is not built into this proof of concept yet." + Environment.NewLine + Environment.NewLine +
                "To remove Gatelog, run Assets\\uninstaller.ps1 from an elevated PowerShell prompt. " +
                "It stops and removes the four services and deletes the install folder.",
                "Uninstall", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void comboBox1_SelectedIndexChanged( object sender, EventArgs e )
        {
            // Show current and available component versions for the selected release
            string? version = comboBox1.SelectedItem as string;
            if (string.IsNullOrEmpty(version))
            {
                return;
            }
            if (await GetLatestVersionsFromS3(version))
            {
                availableUpdates = GetNonMatchingKeys();
            }
        }
    }
}
