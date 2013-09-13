// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFormsAuthenticationService.cs" company="NerverLand">
//   Copyright © 2012 NerverLand UK Ltd, All rights reserved
// </copyright>
// <summary>
//   The interface of FormsAuthenticationService which is used to sign in and sign out
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebApp.Security
{
    /// <summary>
    /// The interface of FormsAuthenticationService which is used to sign in and sign out
    /// </summary>
    public interface IFormsAuthenticationService
    {
        /// <summary>
        /// The sign in.
        /// </summary>
        /// <param name="userName">
        /// The user name.
        /// </param>
        /// <param name="createPersistentCookie">
        /// The create persistent cookie.
        /// </param>
        void SignIn(string userName, bool createPersistentCookie);

        /// <summary>
        /// The sign out.
        /// </summary>
        void SignOut();
    }
}