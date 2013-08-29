// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProductRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The ProductRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using Ojb.Framework.Domain.Interfaces;

namespace Ojb.DataModules.Product.Contract.Repository
{
    /// <summary>
    /// The ProductRepository interface.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface IProductRepository<T> : IRepositoryBase<T> where T : class
    {
    }
}