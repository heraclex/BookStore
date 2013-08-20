using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ojb.DomainServices.Library.ServiceConfiguration
{
    using System.Globalization;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Dispatcher;

    /// <summary>
    /// We'll need to implement an IInstanceProvider that allows us to serve up instances of our service each time WCF needs a new instance.
    /// </summary>
    public class DependencyInjectionInstanceProvider : IInstanceProvider
    {
        // http://orand.blogspot.com/2006/10/wcf-service-dependency-injection.html

        private Type _serviceType;

        public DependencyInjectionInstanceProvider(Type serviceType)
        {
            _serviceType = serviceType;
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return null;
            // return container.Resolve(_serviceType);
        }

        public void ReleaseInstance(System.ServiceModel.InstanceContext instanceContext, object instance) { }
    }
}
