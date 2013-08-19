// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserMapping.cs" company="">
//   
// </copyright>
// <summary>
//   The user mapping.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using Ojb.DataModules.Security.Contract.Domain;
using Ojb.Framework.Mapping;

namespace Ojb.DataModules.Security.Mapping.Mappings
{
    /// <summary>
    /// The user mapping.
    /// </summary>
    public class UserMapping : EntityMappingBase<User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserMapping"/> class.
        /// </summary>
        public UserMapping()
        {
            this.Property(x => x.UserName);
            this.HasMany(x => x.CustomerInfomations);
        }
    }
}