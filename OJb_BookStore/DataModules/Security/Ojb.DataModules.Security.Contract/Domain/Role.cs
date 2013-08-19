// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Role.cs" company="">
//   
// </copyright>
// <summary>
//   The role.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using Ojb.Framework.Domain.Entity;

namespace Ojb.DataModules.Security.Contract.Domain
{
    /// <summary>
    /// The role.
    /// </summary>
    public class Role : AuditEntity
    {
        /// <summary>
        /// Gets or sets the role name.
        /// </summary>
        public virtual string RoleName { get; set; }
    }
}