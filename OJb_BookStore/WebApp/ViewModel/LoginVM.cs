using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.ViewModel
{
    public class LoginVM
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the environment name.
        /// </summary>
        public string EnvironmentName { get; set; }

        /// <summary>
        /// Gets or sets the login model.
        /// </summary>
        public LoginModel LoginModel { get; set; }

        /// <summary>
        /// Gets or sets the organization name.
        /// </summary>
        public string OrganizationName { get; set; }

        /// <summary>
        /// Gets or sets the assistance text.
        /// </summary>
        public string AssistanceText { get; set; }

        /// <summary>
        /// Gets or sets the auto login error message.
        /// </summary>
        public string AutoLoginErrorMessage { get; set; }

        #endregion

        public string Message { get; set; }

        public List<KeyValuePair<string, string>> ListDemo
        {
            get
            {
                return new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("0", "Zero"),
                        new KeyValuePair<string, string>("1", "One"),
                        new KeyValuePair<string, string>("2", "Two"),
                        new KeyValuePair<string, string>("3", "Three"),
                        new KeyValuePair<string, string>("4", "Four"),
                        new KeyValuePair<string, string>("5", "Five"),
                        new KeyValuePair<string, string>("6", "Six"),
                        new KeyValuePair<string, string>("7", "Seven"),
                        new KeyValuePair<string, string>("8", "Enght"),
                        new KeyValuePair<string, string>("9", "Night"),
                    };
            }
        }
    }
}
