namespace Aswig.DataModules.Security.Provider
{
    using Aswig.Framework.Domain.Interfaces;
    using Aswig.Framework.EntityFrameworkProvider;

    public class SecurityRepository<T> : RepositoryBase<T> where T : class, IEntityWithTypedId<int>
    {
        public SecurityRepository(System.Data.Entity.DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
