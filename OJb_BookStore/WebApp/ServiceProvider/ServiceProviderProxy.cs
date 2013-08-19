using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.ServiceProvider
{
    public class ServiceProviderProxy : IServiceProviderProxy
    {
        public int Sum(int x, int y)
        {
            return x + y;
        }
    }
}