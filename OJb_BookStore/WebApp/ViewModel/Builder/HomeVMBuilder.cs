// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeVMBuilder.cs" company="">
//   
// </copyright>
// <summary>
//   The home vm builder.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using Ojb.DomainServices.Contract.Services;

namespace WebApp.ViewModel.Builder
{
    /// <summary>
    /// The home vm builder.
    /// </summary>
    public class HomeVMBuilder : IHomeVMBuilder
    {
        /// <summary>
        /// The product service.
        /// </summary>
        private readonly IProductService productService;

        /// <summary>
        /// The security service.
        /// </summary>
        private readonly ISecurityService securityService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeVMBuilder"/> class.
        /// </summary>
        /// <param name="securityService">
        /// The security service.
        /// </param>
        /// <param name="productService">
        /// The product service.
        /// </param>
        public HomeVMBuilder(ISecurityService securityService, IProductService productService)
        {
            this.securityService = securityService;
            this.productService = productService;
        }

        /// <summary>
        /// The buidler home view.
        /// </summary>
        /// <returns>
        /// The <see cref="HomeVM"/>.
        /// </returns>
        public HomeVM BuidlerHomeView()
        {
            return new HomeVM
                {
                    EmployeeInfoList = securityService.GetAllEmployeeInfo(), 
                    ProductInfoList = productService.GetAllProductInfo()
                };
        }
    }
}