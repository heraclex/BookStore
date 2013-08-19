using System.Configuration;

namespace WebApp.Utilities
{
    public static class WebConfigManager
    {
        public static string Endpoint
        {
            get
            {
                return GetValue("endpoint");
            }
        }

        private static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key] ?? string.Empty;
            
        }
    }
}