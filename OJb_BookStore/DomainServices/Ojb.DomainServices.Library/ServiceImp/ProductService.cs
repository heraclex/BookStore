// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductService.cs" company="">
//   
// </copyright>
// <summary>
//   The product service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Collections.Generic;
using System.Linq;
using Ojb.DataModules.Product.Contract.Domain;
using Ojb.DataModules.Product.Contract.Repository;
using Ojb.DomainServices.Contract.MessageModels;
using Ojb.DomainServices.Contract.Services;
using Ojb.Framework.ServiceBase.Imps;

namespace Ojb.DomainServices.Library.ServiceImp
{
    /// <summary>
    /// The product service.
    /// </summary>
    public class ProductService : ServiceBase, IProductService
    {
        /// <summary>
        ///     The security user repository.
        /// </summary>
        private readonly IProductRepository<Product> ProductRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="productRepository">
        /// The product repository.
        /// </param>
        public ProductService(IProductRepository<Product> productRepository)
        {
            this.ProductRepository = productRepository;
        }

        #region Implementation of IProductService

        /// <summary>
        /// The get all product info.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<ProductInfo> GetAllProductInfo()
        {
            var result = this.ProductRepository.GetAll().ToList();

            return 
            result.Select(
                x =>
                new ProductInfo
                    {
                        Description = x.Description,
                        Id = x.Id,
                        ImagePath = x.ImagePath,
                        UnitPrice = x.UnitPrice
                    });
        }

        #endregion
    }
}