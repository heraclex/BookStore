using System.Collections.Generic;

namespace Ojb.DomainServices.Library.ServiceImp
{
    using System.Linq;

    using Ojb.DataModules.Product.Contract.Domain;
    using Ojb.DataModules.Product.Contract.Repository;
    using Ojb.DomainServices.Contract.MessageModels;
    using Ojb.DomainServices.Contract.Services;
    using Ojb.Framework.ServiceBase.Imps;

    public class ProductService : ServiceBase, IProductService
    {
        /// <summary>
        /// The security user repository.
        /// </summary>
        private readonly IProductRepository<Product> ProductRepository;

        public ProductService(IProductRepository<Product> productRepository)
        {
            this.ProductRepository = productRepository;
        }

        #region Implementation of IProductService

        public IEnumerable<ProductInfo> GetAllProductInfo()
        {
            var result = this.ProductRepository.GetAll().ToList();

            return
                result.Select(
                    x =>
                    new ProductInfo
                        { Description = x.Description, Id = x.Id, ImagePath = x.ImagePath, UnitPrice = x.UnitPrice });
        }

        #endregion
    }
}
