using System;
using System.Configuration;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Aswig.DomainServices.Contract.Services;

namespace WebApp.ServiceProvider
{
    public class ServiceProvider : Aswig.DomainServices.Contract.Services.IServiceProvider
    {
        private const int INT_MIN_RANDOM = 1000000;
        private const int INT_MAX_RANDOM = 2000000;
        private static ChannelFactory<IAccountService> channelFactoryAccountService = null;
        
        private static readonly object s_opLock = new object();
        // private static readonly object s_saLock = new object();
        // private static bool s_isMadeByPass = false;
        // private static ILog _logger = LogManager.GetLogger(typeof(ServiceProvider));

        /// <summary>
        /// We use Channel Factory to create Channel to comunicate with Services
        /// </summary>
        /// <returns></returns>
        public IAccountService GetService()
        {
            IAccountService service = null;

            if (channelFactoryAccountService == null
                || channelFactoryAccountService.State == CommunicationState.Faulted
                || channelFactoryAccountService.State == CommunicationState.Closed)
            {
                lock (s_opLock)
                {
                    channelFactoryAccountService = 
                        new ChannelFactory<IAccountService>(new CustomBinding("customOverHttps"));
                    channelFactoryAccountService.Endpoint.Address = 
                        new EndpointAddress(ConfigurationManager.AppSettings["endpoint"]);
                    
                    service = channelFactoryAccountService.CreateChannel();
                }
            }

            return service;
        }

        public bool AddDataTest(int x)
        { 
            var a = x * 10;
            return a > 1000;
        }

        public int TestData(int x) 
        {
            return x;
        }

        public int ExecSum(int x, int y)
        {
            return x+y;
        }
    
    }
}