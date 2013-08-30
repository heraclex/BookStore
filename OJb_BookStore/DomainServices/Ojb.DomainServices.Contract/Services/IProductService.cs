namespace Ojb.DomainServices.Contract.Services
{
    using System.Collections.Generic;
    using System.ServiceModel;

    using Ojb.DomainServices.Contract.MessageModels;
    using Ojb.Framework.ServiceBase.Contracts;

    [ServiceContract]
    public interface IProductService : IService
    {
        [OperationContract]
        IEnumerable<ProductInfo> GetAllProductInfo();
    }
}
