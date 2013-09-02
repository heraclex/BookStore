// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SecurityService.cs" company="">
//   
// </copyright>
// <summary>
//   The security service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Collections.Generic;
using System.Linq;
using Ojb.DataModules.Security.Contract.Domain;
using Ojb.DataModules.Security.Contract.Repository;
using Ojb.DomainServices.Contract.MessageModels;
using Ojb.DomainServices.Contract.Services;
using Ojb.Framework.ServiceBase.Imps;

namespace Ojb.DomainServices.Library.ServiceImp
{
    /// <summary>
    /// The security service.
    /// </summary>
    public class SecurityService : ServiceBase, ISecurityService
    {
        /// <summary>
        ///     The security user repository.
        /// </summary>
        private readonly ISecurityRepository<User> SecurityUserRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityService"/> class.
        /// </summary>
        /// <param name="securityRepository">
        /// The security repository.
        /// </param>
        public SecurityService(ISecurityRepository<User> securityRepository)
        {
            this.SecurityUserRepository = securityRepository;
        }

        #region Implementation of ISecurityService

        /// <summary>
        /// The get all employee info.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<EmployeeInfo> GetAllEmployeeInfo()
        {
            var result = this.SecurityUserRepository.GetAll().ToList();
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