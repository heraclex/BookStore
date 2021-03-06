﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SecurityService.cs" company="">
//   
// </copyright>
// <summary>
//   The security service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Ojb.DataModules.Security.Contract.Domain;
using Ojb.DataModules.Security.Contract.Repository;
using Ojb.DomainServices.Contract.MessageModels.Response;
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

        public LoginResult Login(string username, string password)
        {
            var account = this.SecurityUserRepository
                .Query<User>(x => x.UserName == username && x.Password == password)
                .Include(c => c.CustomerInfomations).FirstOrDefault();
            if (account == null)
            {
                return new LoginResult
                    {
                        IsSuccess = false, 
                        InvalidLoginInfo = new KeyValuePair<LoginResult.InvalidLoginType, string>(LoginResult.InvalidLoginType.InvalidUsernameOrPassword, "Invalid login. Please try again.")
                    };
            }

            var acountInfomation = account.CustomerInfomations.FirstOrDefault();

            return new LoginResult
                {
                    IsSuccess = true,
                    AccountInfo = new AccountInfo
                        {
                            Id = account.Id,
                            FisrtName = acountInfomation != null ? acountInfomation.FirstName : string.Empty,
                            LastName = acountInfomation != null ? acountInfomation.LastName : string.Empty,
                            UserName = account.UserName,
                            Password = account.Password,
                            PhoneNumber = acountInfomation != null ? acountInfomation.PhoneNumber : string.Empty,
                        }
                };
        }

        #endregion
    }
}