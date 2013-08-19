namespace Aswig.DataModules.Security.Provider
{
    using System.Data.Entity;

    using Aswig.DataModules.Security.Contract.Domain;
    using Aswig.DataModules.Security.Mapping.Mappings;
    using Aswig.Framework.EntityFrameworkProvider;

    public class SecurityDbContext : AswDbContext
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public SecurityDbContext()
            : this("DefaultDb")
        {
        }

        public SecurityDbContext(string connStringName)
            : base(connStringName)
        {
        }

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
