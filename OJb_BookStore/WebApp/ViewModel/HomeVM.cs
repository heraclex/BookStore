﻿
using System.Collections.Generic;
using Ojb.DomainServices.Contract.MessageModels.Response;

namespace WebApp.ViewModel
{
    public class HomeVM
    {
        public IEnumerable<EmployeeInfo> EmployeeInfoList { get; set; }

        public IEnumerable<ProductInfo> ProductInfoList { get; set; }
    }
}