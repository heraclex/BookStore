// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The product repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using Ojb.DataModules.Product.Contract.Repository;
using Ojb.Framework.Domain.Interfaces;
using Ojb.Framework.EntityFrameworkProvider.Repository;

namespace Ojb.DataModules.Product.Provider.Repository
{
    /// <summary>
    /// The product repository.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class ProductRepository<T> : RepositoryBase<T>, IProductRepository<T>
        where T : class, IEntityWithTypedId<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository{T}"/> class.
        /// </summary>
        /// <param name="dbContext">
        /// The db context.
        /// </param>
        public ProductRepository(System.Data.Entity.DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}