namespace Ojb.DomainServices.Contract.Services
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using Ojb.DomainServices.Contract.MessageModels;
    using Ojb.Framework.ServiceBase.Contracts;

    [ServiceContract]
    public interface IAccountService : IService
    {
        [OperationContract]
        IEnumerable<AccountInfo> GetAllAccountInfo();

        [OperationContract]
        IEnumerable<AccountInfo> GetAllAccount();
    }
}
