
namespace VLMS
{
    static class Global
    {
        public static string commonLocalStoragePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Aivid TechVision");
        public static string cmdPath = Environment.ExpandEnvironmentVariables("%SystemRoot%") + @"\System32\cmd.exe";
        public static string setupFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Setups");
        public static string mongoDBExtensoin  = "MongoDB-7.0.1";
        public static string mongoshExtensoin = "mongosh-2.1.1";
        public static string mosquittoExtensoin = "mosquitto-2.0.18";
        public static string botExtensoin = "aividVlms"; 
        public static string portalExtensoin = "nextjs_anpr"; 
    }
}
