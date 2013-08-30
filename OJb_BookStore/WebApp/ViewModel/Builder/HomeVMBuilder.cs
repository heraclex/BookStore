using Ojb.DomainServices.Contract.Services;

namespace WebApp.ViewModel.Builder
{
    public class HomeVMBuilder : IHomeVMBuilder
    {
        private readonly ISecurityService securityService = null;
        private readonly IProductService productService = null;

        public HomeVMBuilder(ISecurityService securityService, IProductService productService)
        {
            this.securityService = securityService;
            this.productService = productService;
        }

        public HomeVM BuidlerHomeView()
        {
            return new HomeVM
                {
                    EmployeeInfoList = this.securityService.GetAllEmployeeInfo(),
                    ProductInfoList = this.productService.GetAllProductInfo()
                };
        }
    }
}