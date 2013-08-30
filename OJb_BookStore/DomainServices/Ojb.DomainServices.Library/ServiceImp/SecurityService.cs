using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ojb.DomainServices.Library.ServiceImp
{
    using Ojb.DataModules.Security.Contract.Domain;
    using Ojb.DataModules.Security.Contract.Repository;
    using Ojb.DomainServices.Contract.MessageModels;
    using Ojb.DomainServices.Contract.Services;
    using Ojb.Framework.ServiceBase.Imps;

    public class SecurityService : ServiceBase, ISecurityService
    {
        /// <summary>
        /// The security user repository.
        /// </summary>
        private readonly ISecurityRepository<User> SecurityUserRepository;

        public SecurityService(ISecurityRepository<User> securityRepository)
        {
            this.SecurityUserRepository = securityRepository;
        }

        #region Implementation of ISecurityService

        public IEnumerable<EmployeeInfo> GetAllEmployeeInfo()
        {
            var result = this.SecurityUserRepository.GetAll();
            return
                result.Select(
                    x =>
                    new EmployeeInfo
                        {
                            Id = x.Id,
                            FisrtName = "Test",
                            LastName = "Test",
                            Password = x.Password,
                            PhoneNumber = "Phone"
                        });
        }

        #endregion
    }
}
