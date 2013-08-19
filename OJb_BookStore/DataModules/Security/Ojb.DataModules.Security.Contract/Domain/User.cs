// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="">
//   
// </copyright>
// <summary>
//   The user.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Collections.Generic;
using Ojb.Framework.Domain.Entity;

namespace Ojb.DataModules.Security.Contract.Domain
{
    /// <summary>
    /// The user.
    /// </summary>
    public class User : AuditEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            CustomerInfomations = new List<UserProfile>();
        }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public virtual string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public virtual string Password { get; set; }

        /// <summary>
        /// Gets or sets the customer infomations.
        /// </summary>
        public virtual IList<UserProfile> CustomerInfomations { get; set; }
    }
}