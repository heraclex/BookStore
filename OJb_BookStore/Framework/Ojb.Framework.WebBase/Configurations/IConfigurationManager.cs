using System.Collections.Specialized;
using System.Configuration;

namespace Ojb.Framework.WebBase.Configurations
{
    public interface IConfigurationManager
    {
        object GetSection(string sectionName);

        ConnectionStringSettingsCollection GetConnectionStrings();

        NameValueCollection GetAppSettings();

        string GetAppConfigBy(string appConfigName); 
    }
}