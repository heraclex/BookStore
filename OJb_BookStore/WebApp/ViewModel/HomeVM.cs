
using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.ViewModel
{
    public class HomeVM
    {
        public List<int> NumberList { get; set; }

        public List<string> NameList { get; set; }

        public List<RegisterModel> AccModelList { get; set; }
    }
}