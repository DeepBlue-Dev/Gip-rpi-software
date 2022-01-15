namespace Configurations.Storage
{
    public static class StorageConfig
    {
        public static string ConfigBasePath = System.IO.Path.Combine(
            System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) ?? string.Empty, "Configs\\");

        public static string EmailConfigurationName = "EmailConfiguration.json";
        
    }
}