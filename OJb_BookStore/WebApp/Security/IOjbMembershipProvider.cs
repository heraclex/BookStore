// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICxMemberShipProvider.cs" company="NerverLand">
//   Copyright © 2012 NerverLand UK Ltd, All rights reserved
// </copyright>
//  <summary>
//   CxMembership Provider Interface
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebApp.Security
{
    #region Namespace
    
    using Ojb.DomainServices.Contract.MessageModels.Response;

    #endregion

    /// <summary>
    ///   The member ship provider interface.
    /// </summary>
    public interface IOjbMemberShipProvider
    {
        #region Public Properties

        string ChangePasswordStatus { get; }
        LoginResult LoginStatus { get; }
        string PrincipalSessionKey { get; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The change password to new password and check old password is match or not.
        /// </summary>
        bool ChangePassword(string username, string oldPassword, string newPassword, ref bool isMacthOldPassword);

        /// <summary>
        /// The validate user and password.
        /// </summary>
        bool ValidateUser(string username, string password);

        #endregion
    }
}