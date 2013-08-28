
using System.Collections.Generic;
using Ojb.DomainServices.Contract.MessageModels;

namespace WebApp.ViewModel
{
    public class HomeVM
    {
        public IEnumerable<AccountInfo> AccountList { get; set; }
    }
}