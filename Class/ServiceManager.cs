using System.Diagnostics;
using System.ServiceProcess;
namespace VLMS
{

    public class ServiceInfo
    {
        public string name;
        public ServiceControllerStatus status;
        public ServiceInfo(string name, ServiceControllerStatus status)
        {
            this.name = name;
            this.status = status;
        }
    }
    public class ServiceManager
    {
        private static string nssmPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "nssm.exe");
        public static Dictionary<string, ServiceInfo> GetAllServices()
        {
            Dictionary<string, ServiceInfo> dict = new Dictionary<string, ServiceInfo>();
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController service in services)
            {
                dict.Add(service.ServiceName, new ServiceInfo(service.ServiceName, service.Status));
            }
            return dict;
        }

        public  static bool IsServicePresent( string serviceName )
        {
            Dictionary<string, ServiceInfo> services = GetAllServices();
            return services.ContainsKey(serviceName);
        }

        public static bool AreAllServicesPresent( string[] serviceNames )
        {
            foreach (string serviceName in serviceNames)
            {
                if (!IsServicePresent(serviceName))
                {
                    return false;
                }
            }
            return true;
        }

        private static void RunCmd(string command)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = Global.cmdPath,
                Arguments = command,
                Verb = "runas",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true
            };
            process.StartInfo = startInfo;
            process.Start();
            string strOutput = process.StandardOutput.ReadToEnd();
            Debug.WriteLine(strOutput);
            Debug.WriteLine(startInfo.Arguments);
            Debug.WriteLine(startInfo.FileName);
            process.Kill();
        }
        public static  void StartExistingService(string serviceName)
        {
            // Outer quotes are stripped by cmd /C; the inner ones keep a path with spaces intact
            RunCmd($"/C \"\"{nssmPath}\" start {serviceName}\"");
        }
        public static void WaitForServiceToStart( string serviceName , ServiceControllerStatus serviceControllerStatus )
        {
            Dictionary<string, ServiceInfo> dict = new Dictionary<string, ServiceInfo>();
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController service in services)
            {
                if(service.ServiceName == serviceName)
                {
                    service.WaitForStatus(serviceControllerStatus);
                } 
            }
        }

        public static void StopExistingService(string serviceName)
        {
            RunCmd($"/C \"\"{nssmPath}\" stop {serviceName}\"");
        }
        public static bool IsPresentInSystem(string servicename)
        {
            Dictionary<string, ServiceInfo> dict = GetAllServices();
            return dict.ContainsKey(servicename);
        }
        public void RemoveService(string serviceName)
        {
            RemoveFromWindowsService(serviceName);
            try
            {
               // File.Delete($"{Global.commonStoragePath}/configuredConnects/{serviceName}/{serviceName}.bat");
            }
            catch (Exception)
            {

            }

        }
        public void InstallService( string serviceName, string prefixServicePathWithName )
        {
        
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
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + ex.StackTrace);
            }
        }
        public static void RemoveFromWindowsService(string serviceName)
        {
            StopExistingService(serviceName);
            RunCmd($"/C \"\"{nssmPath}\" remove {serviceName} confirm\"");
        }
    }
}
