// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SecurityRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The security repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Data.Entity;
using Ojb.DataModules.Security.Contract.Repository;
using Ojb.Framework.Domain.Interfaces;
using Ojb.Framework.EntityFrameworkProvider.Repository;

namespace Ojb.DataModules.Security.Provider.Repository
{
    /// <summary>
    /// The security repository.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class SecurityRepository<T> : RepositoryBase<T> where T : class, ISecurityRepository<T>, IEntityWithTypedId<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityRepository{T}"/> class.
        /// </summary>
        /// <param name="dbContext">
        /// The db context.
        /// </param>
        public SecurityRepository(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}