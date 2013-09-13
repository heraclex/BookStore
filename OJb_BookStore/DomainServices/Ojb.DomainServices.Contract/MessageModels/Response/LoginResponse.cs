namespace Ojb.DomainServices.Contract.MessageModels.Response
{

    #region Declarations

    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// Login result contains information returned by Login service.
    /// </summary>
    public class LoginResult
    {
        #region Declarations

        /// <summary>
        /// The invalid login type.
        /// </summary>
        public enum InvalidLoginType
        {
            /// <summary>
            /// Login successfully.
            /// </summary>
            None,

            /// <summary>
            /// The invalid username or password.
            /// </summary>
            InvalidUsernameOrPassword,

            /// <summary>
            /// The user locked.
            /// </summary>
            UserLocked,

            /// <summary>
            /// The no access right.
            /// </summary>
            NoAccessRight
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether is success.
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is forced change password.
        /// </summary>
        public bool IsForcedChangePassword { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public KeyValuePair<InvalidLoginType, string> InvalidLoginInfo { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        public AccountInfo AccountInfo { get; set; }

        #endregion
    }
}
