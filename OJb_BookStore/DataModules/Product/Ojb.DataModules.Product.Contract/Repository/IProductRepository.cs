
namespace Ojb.DataModules.Product.Contract.Repository
{
    using Ojb.Framework.Domain.Interfaces;

    public interface IProductRepository<T> : IRepositoryBase<T> where T : class
    {
    }
}
