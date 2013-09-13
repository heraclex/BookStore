using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.ViewModel
{
    using WebApp.Models;

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
    }
}