// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserProfile.cs" company="">
//   
// </copyright>
// <summary>
//   The user profile.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace Ojb.DataModules.Security.Contract.Domain
{
    using Framework.Domain.Entity;

    /// <summary>
    /// The user profile.
    /// </summary>
    public class UserProfile : AuditEntity
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public virtual string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public virtual string LastName { get; set; }

        /// <summary>
        /// Gets or sets the middle name.
        /// </summary>
        public virtual string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public virtual string Address { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        public virtual string PhoneNumber { get; set; }
    }
}