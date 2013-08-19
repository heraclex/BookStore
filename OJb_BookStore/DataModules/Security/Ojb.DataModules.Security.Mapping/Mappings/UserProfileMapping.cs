// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserProfileMapping.cs" company="">
//   
// </copyright>
// <summary>
//   The user profile mapping.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using Ojb.DataModules.Security.Contract.Domain;
using Ojb.Framework.Mapping;

namespace Ojb.DataModules.Security.Mapping.Mappings
{
    /// <summary>
    /// The user profile mapping.
    /// </summary>
    public class UserProfileMapping : EntityMappingBase<UserProfile>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfileMapping"/> class.
        /// </summary>
        public UserProfileMapping()
        {
            this.Property(x => x.FirstName);
            this.Property(x => x.LastName);
            this.Property(x => x.MiddleName);
            this.Property(x => x.Address);
            this.Property(x => x.PhoneNumber);
        }
    }
}