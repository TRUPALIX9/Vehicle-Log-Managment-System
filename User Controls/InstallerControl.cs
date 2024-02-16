using Krypton.Toolkit;
using System.Diagnostics;
using System.IO.Compression;
namespace VLMS
{
    public partial class InstallerControl : UserControl
    {
        #region Global Variables
        FolderBrowserDialog folderDlg = new FolderBrowserDialog();
        private bool isInstallationComplete = false;
        private bool isInstallationStarted = false;
        private string globalVLMSStoragePath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        #endregion

        #region UserControl2 Main 
        public InstallerControl()
        {
            InitializeComponent();
        }
        private void UserControl2_Load( object sender, EventArgs e )
        {
            lbl_title.Text = "Please Select Installtion Location";
            toggleShow(false);
            progressBar.Visible = false;
            textBox1.Text = globalVLMSStoragePath;
        }
        #endregion

        #region useContronl2 Event Handlers

        private void button2_Click( object sender, EventArgs e )
        {
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = folderDlg.SelectedPath;
                globalVLMSStoragePath = folderDlg.SelectedPath;
            }
        }
        private void btn_next_Click( object sender, EventArgs e )
        {
            string pathWithVLMS = Path.Combine(globalVLMSStoragePath, "VLMS");
            globalVLMSStoragePath = pathWithVLMS;
            if (!isInstallationStarted)
            {
                if (!Directory.Exists(pathWithVLMS))
                {
                    Directory.CreateDirectory(pathWithVLMS);
                }
                // First click
                textBox1.Enabled = false;
                btn_fileDialog.Enabled = false;
                isInstallationStarted = true;
                btn_continue_finish.Enabled = false;
                btn_continue_finish.Text = "Finish";
                lbl_title.Text = "Installing AIVID VLMS, Please wait...";
                progressBar.Visible = true;
                toggleShow(true);
                _ = RunInstaller();

            }
            else if (isInstallationComplete)
            {
                string url = "https://localhost";

                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                System.Windows.Forms.Application.Exit();
            }

        }

        private void textBox1_TextChanged( object sender, EventArgs e )
        {
            globalVLMSStoragePath = textBox1.Text;
        }
        #endregion

        #region Helpers
        private void ExtractZip( string filePathExtension )
        {
            string extractPath = globalVLMSStoragePath;
            string zipFilePath = Path.Combine( Global.setupFolderPath ,filePathExtension) + ".zip";
            try
            {
                  if (!Directory.Exists(Path.Combine(extractPath, filePathExtension)))
                  {
                    InvokeWriteToEventLog($"Exstracting {filePathExtension} ...");
                    ZipFile.ExtractToDirectory(zipFilePath, extractPath);
                    InvokeWriteToEventLog($"ZipFile extracted to {extractPath} Successfuly");
                  }
                   else
                   {
                       InvokeWriteToEventLog($"{extractPath}/{filePathExtension} Already Exsist So Zip Extraction skipped");
                   }

            }
            catch (Exception ex)
            {
                InvokeWriteToEventLog($"Error extracting {zipFilePath}: {ex.Message}");
            }
        }
        public void WriteToEventLog( string message )
        {
            if (richTextBox.InvokeRequired)
            {
                richTextBox.Invoke(new Action(() => WriteToEventLog(message)));
            }
            else
            {
                richTextBox.AppendText($"{DateTime.Now:dd-MM-yyyy HH:mm:ss} : {message} {Environment.NewLine}");
            }
        }

        static void CreateDirectoryIfNotExists( string directoryPath )
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }
        private void ExecuteCommandAndLog( string logMessage, string command, string arguments )
        {
            InvokeWriteToEventLog(logMessage);
            RunCommand(command, arguments, richTextBox);
        }
        #endregion

        #region Form Updation
        public void UpdateControls( string title, int number )
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    lbl_step.Text = title;
                    progressBar.Value = Math.Max(0, Math.Min(number, progressBar.Maximum));
                }));
            }
            else
            {
                lbl_step.Text = title;
                progressBar.Value = Math.Max(0, Math.Min(number, progressBar.Maximum));
            }
        }
        private void toggleShow( bool show )
        {
            lbl_step.Visible = show;
            richTextBox.Visible = show;
            lbl_logs.Visible = show;
        }
        private void afterInstalltion()
        {
            isInstallationComplete = true;
            btn_continue_finish.Enabled = true;
            lbl_title.Text = "Installation Completed For AIVID VLMS";
            lbl_logs.Text = "Click Finish to Open Vehical Log Mangment System";

        }
        #endregion

        #region RunInstaller Function

        public async Task RunInstaller()
        {
            try
            {
                
                // Step 1
                UpdateControls("Extracting MongoDB Server ZIp", 3);
                await Task.Run(() => ExtractZip(Global.mongoDBExtensoin));
                // Step 2
                UpdateControls("Extracting Mongosh ZIp", 29);
                await Task.Run(() => ExtractZip(Global.mongoshExtensoin));
                // Step 3
                UpdateControls("Installing Mqtt Service", 36);
                await Task.Run(() => InstallMQTT());
                // Step 4
                UpdateControls("Configuring MongoDB Server ZIp", 49);
                await Task.Run(() => ConfigureMongoDB());
                // Step 5
                UpdateControls("Creating MongoDBUser", 57);
                await Task.Run(() => CreateUserInMongoDB());
                // Step 6
                UpdateControls("Extracting ANPR NEXT", 64);
                await Task.Run(() => ExtractZip(Global.portalExtensoin));
                // Step 7
                UpdateControls("Extracting BOT VLMS", 81);
                await Task.Run(() => ExtractZip(Global.botExtensoin));
                // Step 8
                UpdateControls("Setting Up Portal services", 93);
                InstallService("aividPortal", Path.Combine(globalVLMSStoragePath, $"{Global.portalExtensoin}\\vlms") );
                UpdateControls("Setting Up Portal services", 98);
                InstallService("aividVLMSBot", Path.Combine(globalVLMSStoragePath, $"{Global.botExtensoin}\\{Global.botExtensoin}") );
                UpdateControls("Installation Complete", 100);
                WriteToEventLog("-----DONE------");
                afterInstalltion();
            }
            catch (Exception ex)
            {
                // Handle the exception, call cleanup function, and log the error with the function name and step number
                HandleError(ex);
            }
        }
        private void HandleError( Exception ex )
        {
            // Perform cleanup operations here
            // Log the error or take any necessary actions
            WriteToEventLog($"Error occurred in: {ex.Message}");

            // Call cleanup function with the step number
            return;
        }
     
        #endregion

        #region MongoDB 
        private void ConfigureMongoDB()
        {
            try
            {
                string installDirectory = $"{globalVLMSStoragePath}\\{Global.mongoDBExtensoin}";
                string mongoBinDirectory = Path.Combine(installDirectory, "bin");
                string dataDirectory = Path.Combine(installDirectory, "data");
                string mongoLogsDirectory = Path.Combine(installDirectory, "mongoLogs");
                string ipAddress = "127.0.0.1";
                int port = 27017;
                CreateDirectoryIfNotExists(dataDirectory);
                CreateDirectoryIfNotExists(mongoLogsDirectory);
                // Configure MongoDB as a service
                string installCommand = $"--auth --bind_ip {ipAddress} --port {port} --install -dbpath \"{dataDirectory}\" --logpath \"{mongoLogsDirectory}\\mongodb.log\" --serviceName MongoDB --serviceDisplayName MongoDBAIVID";
                ExecuteCommandAndLog(installCommand, Path.Combine(mongoBinDirectory, "mongod"), installCommand);
                // Start MongoDB service
                string startServiceCommand = "net start MongoDB";
                ExecuteCommandAndLog("starting MongoDBAIVID service...", "cmd.exe", $"/c {startServiceCommand}");
    
            }
            catch (Exception ex)
            {
                InvokeWriteToEventLog(ex.ToString() + Environment.NewLine + ex.StackTrace);
            }

        }
        private void CreateUserInMongoDB()
        {
            try
            {
                // Running shell command to load createUser.js file in Mongoshell with admin 
                string mongoshDirectory = $"{globalVLMSStoragePath}\\{Global.mongoshExtensoin}\\bin";
                RunMongoshScript(mongoshDirectory, "createUser.js" , "admin");
            }
            catch (Exception ex)
            {
                InvokeWriteToEventLog(ex.ToString() + Environment.NewLine + ex.StackTrace);
            }
        }

        #endregion

        #region LOggers 

        private void InvokeWriteToEventLog( string logMessage )
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => WriteToEventLog(logMessage)));
            }
            else
            {
                WriteToEventLog(logMessage);
            }
        }

        #endregion

        #region MQTT mosquitto
        private void InstallMQTT()
        {
            string installerPath = $"{Global.setupFolderPath}\\{Global.mosquittoExtensoin}.exe";
            string MQTTFolder = $"{globalVLMSStoragePath}\\MQTT";
            CreateDirectoryIfNotExists(MQTTFolder);
            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = installerPath;
                    process.StartInfo.Arguments = $"/S /D={MQTTFolder}"; // Silent installation with custom installation directory
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                    process.WaitForExit(); // Optional: Wait for the process to finish

                }
                InvokeWriteToEventLog("MQTT Installation completed successfully Now Starting as a Service.");
                RunCommand(Path.Combine(MQTTFolder, "mosquitto.exe"), "-install");
                string startServiceCommand = "net start mosquitto";
                RunCommand("cmd.exe", $"/c {startServiceCommand}");
                }
            catch (Exception ex)
            {
                InvokeWriteToEventLog($"Error: {ex.Message}");
            }
        }
        #endregion

        #region NSSM INStall Start Stop Command

        public void InstallService( string serviceName, string prefixServicePathWithName )
        {
            string nssmPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "nssm.exe");
            try
            {
                RunCmd($"{nssmPath} install {serviceName} \"{prefixServicePathWithName}.exe\"");
                RunCmd($"{nssmPath} set {serviceName} AppStdout \"{prefixServicePathWithName}-output.log\"");
                RunCmd($"{nssmPath} set {serviceName} AppStderr \"{prefixServicePathWithName}-error.log\"");
                RunCmd($"{nssmPath} set {serviceName} AppStdoutCreationDisposition 4");
                RunCmd($"{nssmPath} set {serviceName} AppStderrCreationDisposition 4");
                RunCmd($"{nssmPath} set {serviceName} AppRotateFiles 1");
                RunCmd($"{nssmPath} set {serviceName} AppRotateSeconds 86400");
                RunCmd($"{nssmPath} set {serviceName} AppRotateBytes 1024");
                RunCmd($"{nssmPath} set {serviceName} Start SERVICE_AUTO_START");
                RunCmd($"{nssmPath} set {serviceName} AppRestartDelay 60000");
                RunCmd($"sc failure \"{serviceName}\" actions= restart/60000/restart/60000/restart/60000 reset= 86400");
                StartExistingService(serviceName);
            }
           catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + ex.StackTrace );
            }
        }
        public void StartExistingService( string serviceName )
        {
            string nssmPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "nssm.exe");
            RunCmd($" {nssmPath} start {serviceName}");
            Thread.Sleep(5000);
        }
        public void StopExistingService( string serviceName )
        {
            string nssmPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "nssm.exe");
            RunCmd($" {nssmPath} stop {serviceName}");
        }
        #endregion

        #region RunCMD Function 
        private void RunCmd( string command )
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = "cmd.exe",
                Arguments = $"/C {command}",  // Add /C flag here
                Verb = "runas",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true
            };
            process.StartInfo = startInfo;
        

            process.Start();
            string strOutput = process.StandardOutput.ReadToEnd();
            InvokeWriteToEventLog(strOutput);
            process.Kill();
        }
          private void RunCommand( string fileName, string arguments, KryptonRichTextBox outputTextBox = null )
        {
            Process process = new Process();
            process.StartInfo.FileName = fileName;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.EnableRaisingEvents = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.OutputDataReceived += ( sender, e ) => { if (e.Data != null) { InvokeWriteToEventLog(e.Data); } };
            process.ErrorDataReceived += ( sender, e ) => { if (e.Data != null) { InvokeWriteToEventLog($"Error: {e.Data}"); } };
            process.Start();
            process.BeginOutputReadLine();
            process.WaitForExit();
        }
        private void RunMongoshScript( string mongoshPath, string scriptPath, string databaseName )
        {
            Process process = new Process();
            process.StartInfo.FileName = $"cmd.exe";
            process.StartInfo.WorkingDirectory = mongoshPath;
            string command = $"mongosh.exe {databaseName} < {scriptPath}";
            InvokeWriteToEventLog("Creating User" +" "+  process.StartInfo.Arguments);
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            // Optionally, provide input from a file
            process.StandardInput.WriteLine(command);
            process.StandardInput.Close(); // Close the input stream to signal the end of input
            // Read the output and error streams if needed
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            InvokeWriteToEventLog(output +Environment.NewLine + error);

            process.WaitForExit();
        }
        #endregion

    }
}
