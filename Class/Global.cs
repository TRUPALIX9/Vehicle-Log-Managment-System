
namespace VLMS
{
    static class Global
    {
        public static string productName = "Gatelog";
        // Folder created under the chosen install location, e.g. C:\Program Files\Gatelog
        public static string installFolderName = "Gatelog";
        public static string commonLocalStoragePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Gatelog");
        public static string cmdPath = Environment.ExpandEnvironmentVariables("%SystemRoot%") + @"\System32\cmd.exe";
        public static string setupFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Setups");
        public static string mongoDBExtensoin  = "MongoDB-7.0.1";
        public static string mongoshExtensoin = "mongosh-2.1.1";
        public static string mosquittoExtensoin = "mosquitto-2.0.18";
        public static string botExtensoin = "gatelogBot";
        public static string portalExtensoin = "nextjs_anpr";

        // Windows services registered by the installer
        public static string portalServiceName = "gatelogPortal";
        public static string botServiceName = "gatelogBot";
        public static string[] serviceNames = { botServiceName, portalServiceName, "MongoDB", "mosquitto" };

        // Update channel (S3). Configure with environment variables; see .env.example.
        public static string updateBucketName = Environment.GetEnvironmentVariable("GATELOG_UPDATE_BUCKET") ?? string.Empty;
        public static string updateRegion = Environment.GetEnvironmentVariable("GATELOG_UPDATE_REGION") ?? "us-east-1";
        public static string updatePrefix = Environment.GetEnvironmentVariable("GATELOG_UPDATE_PREFIX") ?? "releases";
    }
}
