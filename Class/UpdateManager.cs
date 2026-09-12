using Amazon.S3.Transfer;
using Amazon.S3;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime.Internal;
using Amazon.S3.Model;
using VLMS.User_Controls;
using System.Windows.Forms;

namespace VLMS.Class
{
    internal class UpdateManager
    {
        // Full path of config.json (SaveConfig writes here)
        private static string filePath = Path.Combine(Properties.Settings.Default.baseVlmsPath, "config.json");
        private static Dictionary<string, string> configData;

        public static void CreateConfigFileIfNotExists( string basePath = "C:\\Program Files\\Gatelog" )
        {
            string configPath = Path.Combine(basePath, "config.json");
            UpdaeteFilePath(configPath);

            // Check if config.json already exists
            if (File.Exists(configPath))
            {
                LoadConfig(configPath);
                return;
            }
            // Config values
            var defaultConfig = new
            {
                mainVersion="1.0.0",
                nextjs_anpr = "1.0.0",
                gatelogBot = "1.0.0",
            };
            // Write config to file, then load it so GetValue/SetValue have data on first run
            File.WriteAllText(configPath, JsonConvert.SerializeObject(defaultConfig, Formatting.Indented));
            LoadConfig(configPath);
            MessageBox.Show($"config.json created at {configPath}");
        }

        public static void LoadConfig( string basePath )
        {
            try
            {
                string json = File.ReadAllText(basePath);
                configData = JsonConvert.DeserializeObject<Dictionary<string, string>>(json) ?? new Dictionary<string, string>();
            }
            catch (Exception ex)
            {
                Console.Write($"Error loading config file: {ex.Message}");
               // CreateConfigFileIfNotExists(Properties.Settings.Default.baseVlmsPath);
            }
        }
        public static void UpdaeteFilePath( string configPath )
        {
            filePath = configPath;
        }

        public static string GetValue( string key )
        {
            CreateConfigFileIfNotExists(Properties.Settings.Default.baseVlmsPath);
            if (configData != null && configData.ContainsKey(key))
            {
                return configData[key];
            }
            else
            {
                return null;
            }
        }

        public static void SetValue( string key, string value )
        {
            if (configData == null)
            {
                CreateConfigFileIfNotExists(Properties.Settings.Default.baseVlmsPath);
            }
            configData ??= new Dictionary<string, string>();
            configData[key] = value;
            SaveConfig();
        }

        private static void SaveConfig()
        {
            try
            {
                string json = JsonConvert.SerializeObject(configData, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving config file: {ex.Message}");
            }
        }

        public static string? GetServiceStartupPath( string serviceName )
        {
            try
            {
                using (RegistryKey serviceKey = Registry.LocalMachine?.OpenSubKey($@"SYSTEM\CurrentControlSet\Services\{serviceName}"))
                {
                    if (serviceKey != null)
                    {
                        object imagePath = serviceKey.GetValue("ImagePath");

                        if (imagePath != null)
                        {
                            string serviceCommand = imagePath.ToString().Trim('"');

                            int vlmsIndex = serviceCommand.IndexOf(Global.installFolderName);

                            if (vlmsIndex != -1)
                            {
                                // Extract the substring from the beginning of the command until the install folder name
                                string extractedPath = serviceCommand.Substring(0, vlmsIndex + Global.installFolderName.Length);
                                CreateConfigFileIfNotExists(extractedPath);
                                Properties.Settings.Default.baseVlmsPath = extractedPath;
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
        public  static async Task UnzipS3ObjectAsync( string objectKey, string destinationPath )
        {
            using (var s3Client = new AmazonS3Client(RegionEndpoint.GetBySystemName(Global.updateRegion)))
            {
                var request = new GetObjectRequest { BucketName = Global.updateBucketName, Key = objectKey };
                MessageBox.Show(objectKey);
                using var response = await s3Client.GetObjectAsync(request);
                using var zip = new ZipArchive(response.ResponseStream, ZipArchiveMode.Read);
                Parallel.ForEach(zip.Entries, entry =>
                {
                    try
                    {
                        string entryPath = Path.Combine(destinationPath, entry.FullName.Replace('/', '\\'));
                        string entryDirectory = Path.GetDirectoryName(entryPath.Replace('/', '\\'));
                        if (!Directory.Exists(entryDirectory))
                        {
                            Directory.CreateDirectory(entryDirectory);
                        }
                        // Extract the entry
                        using (var entryStream = entry.Open())
                        using (var fileStream = File.OpenWrite(entryPath))
                        {
                            entryStream.CopyTo(fileStream);
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                });
            }
        }
    }
}