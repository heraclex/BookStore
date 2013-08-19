// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoleMapping.cs" company="">
//   
// </copyright>
// <summary>
//   The role mapping.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using Ojb.DataModules.Security.Contract.Domain;
using Ojb.Framework.Mapping;

namespace Ojb.DataModules.Security.Mapping.Mappings
{
    /// <summary>
    /// The role mapping.
    /// </summary>
    public class RoleMapping : EntityMappingBase<Role>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleMapping"/> class.
        /// </summary>
        public RoleMapping()
        {
            this.Property(x => x.RoleName);
        }
    }
}