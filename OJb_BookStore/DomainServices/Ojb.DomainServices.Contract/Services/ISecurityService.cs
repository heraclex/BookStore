
namespace Ojb.DomainServices.Contract.Services
{
    using System.Collections.Generic;
    using System.ServiceModel;

    using Ojb.DomainServices.Contract.MessageModels.Response;
    using Ojb.Framework.ServiceBase.Contracts;

    [ServiceContract]
    public interface ISecurityService : IService
    {
        [OperationContract]
        IEnumerable<EmployeeInfo> GetAllEmployeeInfo();
    }
}
