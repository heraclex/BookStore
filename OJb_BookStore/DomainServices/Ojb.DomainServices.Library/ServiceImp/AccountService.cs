using System.Collections.Generic;
using Ojb.DomainServices.Contract.MessageModels;
using Ojb.DomainServices.Contract.Services;
using Ojb.Framework.ServiceBase.Imps;

namespace Ojb.DomainServices.Library.ServiceImp
{
    public class AccountService : ServiceBase, IAccountService
    {
        List<AccountInfo> IAccountService.GetAllAccountInfo()
        {
            return new List<AccountInfo>()
                       {
                           new AccountInfo
                               {
                                   Id = 1, FisrtName = "A", LastName = "B", Password = "123", PhoneNumber = "12345678", UserName = "a", 
                               }
                       };               
        }
    }
}
