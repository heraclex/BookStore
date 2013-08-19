using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aswig.DomainServices.Contract.Models;
using Aswig.DomainServices.Contract.Services;

namespace Aswig.DomainServices.Library
{
    public class AccountService : IAccountService
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
