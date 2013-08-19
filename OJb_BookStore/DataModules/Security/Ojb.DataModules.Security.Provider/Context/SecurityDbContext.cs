// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SecurityDbContext.cs" company="">
//   
// </copyright>
// <summary>
//   The security db context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Data.Entity;
using Ojb.DataModules.Security.Contract.Domain;
using Ojb.DataModules.Security.Mapping.Mappings;
using Ojb.Framework.EntityFrameworkProvider;

namespace Ojb.DataModules.Security.Provider.Context
{
    using Ojb.Framework.EntityFrameworkProvider.DbContext;

    /// <summary>
    /// The security db context.
    /// </summary>
    public class SecurityDbContext : OjbDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityDbContext"/> class.
        /// </summary>
        public SecurityDbContext()
            : this("DefaultDb")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityDbContext"/> class.
        /// </summary>
        /// <param name="connStringName">
        /// The conn string name.
        /// </param>
        public SecurityDbContext(string connStringName)
            : base(connStringName)
        {
        }

        /// <summary>
        /// Gets or sets the user profiles.
        /// </summary>
        public DbSet<UserProfile> UserProfiles { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// The on model creating.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // will be refactored to Module and registerd automatically
            modelBuilder.Configurations.Add(new UserProfileMapping());
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new RoleMapping());
        }
    }
}