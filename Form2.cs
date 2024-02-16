using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Win32;
using System.Text;
using VLMS.Class;

namespace VLMS
{
    public partial class Form2 : Form
    {


        #region Global variables 
        private const string bucketName = "aivid-vlms-anpr-det";
        private readonly IAmazonS3 s3Client;
        Dictionary<string, (string, string)> versionDictionary = new Dictionary<string, (string, string)>();

        Dictionary<string, string> versionDict = new Dictionary<string, string>();
        Dictionary<string, string> jsonDict = new Dictionary<string, string>();
        #endregion


        public Form2()
        {
            InitializeComponent();
            s3Client = new AmazonS3Client(RegionEndpoint.APSouth1);
        }
    
        // Display the non-matching keys
        private List<string> GetNonMatchingKeys( Dictionary<string, string> dict1, Dictionary<string, string> dict2 )
        {
            List<string> nonMatchingKeys = new List<string>();

            foreach (var kvp in dict1)
            {
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
        private void Form2_Load( object sender, EventArgs e )
        {
            comboBoxFiles.SelectedIndex = 0;
            //CheckForUpdate();
            string serviceName = "mongoDb"; // Replace with the actual service name
            string? extractedPath = GetServiceStartupPath(serviceName);
            PrintSettings();
        }

        private void PrintSettings()
        {
            string programFilesPath = Properties.Settings.Default.baseVlmsPath;
            bool isInstalled = Properties.Settings.Default.isInstalled;
            MessageBox.Show("Vlms Path : "+programFilesPath +Environment.NewLine+ "isInstalled: "+ isInstalled.ToString());
        }

        private async void CheckForUpdate()
        {
            //Load Client side Config.Json in Directory
            LoadConfigJson();
            // Wait for both tasks to complete
            await Task.WhenAll(GetLatestVersionFromS3("nextjs_anpr"), GetLatestVersionFromS3("aividVlms"));

            // Extract the keys which versions doesnt match
            List<string> nonMatchingKeys = GetNonMatchingKeys(jsonDict, versionDict);
            StringBuilder labelTextBuilder = new StringBuilder();

            // Iterate over the dictionary entries
            foreach (var kvp in versionDictionary)
            {
                // Append the key and values to the StringBuilder with formatting
                labelTextBuilder.AppendLine($"App: {kvp.Key}");
                labelTextBuilder.AppendLine($"   Current Version: {kvp.Value.Item1}");
                labelTextBuilder.AppendLine($"   Updated Version: {kvp.Value.Item2}");
                labelTextBuilder.AppendLine(); // Add an empty line for separation
            }

            // Convert the StringBuilder to a string
            string labelText = labelTextBuilder.ToString();

            // Assign the formatted text to the label
             //.Text = labelText;
            // enable update buttons;
            EnableButtonsBasedOnListContent(nonMatchingKeys);


            // Display the non-matching keys in the RichTextBox or any other control
            foreach (string key in nonMatchingKeys)
            {
                richTextBox1.AppendText($" {Environment.NewLine} {key}{Environment.NewLine}");
            }
        }
        private async  Task GetLatestVersionFromS3( string key )
        {
            try
            {
                var getObjectTaggingRequest = new GetObjectTaggingRequest
                {
                    BucketName = bucketName,
                    Key = "release/" + key + ".zip"
                };
                var getObjectTaggingResponse = await s3Client.GetObjectTaggingAsync(getObjectTaggingRequest);
                // Print the entire response
                //  richTextBox1.Text += ($"Response: {JsonConvert.SerializeObject(getObjectTaggingResponse, Formatting.Indented)}");
                foreach (var tag in getObjectTaggingResponse.Tagging)
                {
                    richTextBox1.Text += Environment.NewLine + ($"{key}: {tag.Value}");
                    AddIfNotExsists(key, tag.Value, versionDict);
                    var tuple = versionDictionary[key];

                    // Update the second value in the tuple
                    tuple.Item2 = tag.Value;
                    // Assign the updated tuple back to the dictionary
                    versionDictionary[key] = tuple;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
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
        private bool IsNewerVersion( string latestVersion, string clientVersion )
        {
            // Assuming versions are in the format X.Y.Z and can be compared as strings
            return string.Compare(latestVersion, clientVersion) > 0;
        }
        private void btnDownload_Click( object sender, EventArgs e )
        {
        }

        private void LoadConfigJson()
        {
            try
            {
                string jsonFilePath = AppDomain.CurrentDomain.BaseDirectory + "config.json"; // Replace with your JSON file path
                if (File.Exists(jsonFilePath))
                {
                    string jsonData = File.ReadAllText(jsonFilePath);
                    //  richTextBox1.Text = jsonData;
                    DataModel dataModel = System.Text.Json.JsonSerializer.Deserialize<DataModel>(jsonData);
                    AddIfNotExsists("nextjs_anpr", dataModel.nextjs_anpr, jsonDict);
                    AddIfNotExsists("aividVlms", dataModel.aividVlms, jsonDict);


                    // Add key-value pairs to the dictionary
                    versionDictionary.Add("nextjs_anpr", (dataModel.nextjs_anpr, dataModel.nextjs_anpr));
                    versionDictionary.Add("aividVlms", (dataModel.aividVlms, dataModel.aividVlms));

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
        private void button1_Click( object sender, EventArgs e )
        {


        }

        private void EnableButtonsBasedOnListContent( List<string> nonMatchingKeys )
        {
            // Enable Button1 if the list contains "nextjs_anpr"
            btnNextJs.Enabled = nonMatchingKeys.Contains("nextjs_anpr");
            // Enable Button2 if the list contains "aividVlms"
            btn_aividVlms.Enabled = nonMatchingKeys.Contains("aividVlms");
        }
        private static string? GetServiceStartupPath( string serviceName )
        {
            try
            {
                using (RegistryKey serviceKey = Registry.LocalMachine.OpenSubKey($@"SYSTEM\CurrentControlSet\Services\{serviceName}"))
                {
                    if (serviceKey != null)
                    {
                        object imagePath = serviceKey.GetValue("ImagePath");

                        if (imagePath != null)
                        {
                            string serviceCommand = imagePath.ToString().Trim('"');

                            int vlmsIndex = serviceCommand.IndexOf("VLMS");

                            if (vlmsIndex != -1)
                            {
                                // Extract the substring from the beginning of the command until "VLMS"
                                string extractedPath = serviceCommand.Substring(0, vlmsIndex + 4);
                                Properties.Settings.Default.baseVlmsPath = extractedPath;
                                Properties.Settings.Default.isInstalled = true;
                                Properties.Settings.Default.Save();
                                return extractedPath;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Unable to determine service startup path.");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Service '{serviceName}' not found in the registry.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            // Return null if the path extraction fails
            return null;
        }

        private void GetServiceStartupPathButton_Click( object sender, EventArgs e )
        {
        }



    }
}
public class DataModel
{
    public string nextjs_anpr { get; set; }
    public string aividVlms { get; set; }
    public string basePath { get; set; }
}