using Ojb.DomainServices.Contract.Services;

namespace WebApp.ViewModel.Builder
{
    public class HomeVMBuilder : IHomeVMBuilder
    {
        private readonly IAccountService service = null;
        public HomeVMBuilder(IAccountService service)
        {
            this.service = service;
        }

        public HomeVM BuidlerHomeView()
        {
            var a = this.service.GetAllAccountInfo();
            return new HomeVM();
        }
    }
}