// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FormsAuthenticationService.cs" company="NerverLand">
//   Copyright © 2012 NerverLand UK Ltd, All rights reserved
// </copyright>
// <summary>
//   The forms authentication service which is used to sign in and sign out
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebApp.Security
{
    #region Namespace

    using System.Web.Security;

    using Ojb.Framework.Common.Exception;

    #endregion

    /// <summary>
    ///   The forms authentication service which is used to sign in and sign out
    /// </summary>
    public class FormsAuthenticationService : IFormsAuthenticationService
    {
        #region Public Methods and Operators

        /// <summary>
        /// The sign in.
        /// </summary>
        /// <param name="userName">
        /// The user name. 
        /// </param>
        /// <param name="createPersistentCookie">
        /// The create persistent cookie. 
        /// </param>
        public void SignIn(string userName, bool createPersistentCookie)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new OjbException("UserName cannot be null or empty.");
            }

            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        }

        /// <summary>
        ///   The sign out.
        /// </summary>
        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        #endregion
    }
}