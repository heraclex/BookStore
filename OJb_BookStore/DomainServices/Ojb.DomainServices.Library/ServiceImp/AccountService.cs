﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountService.cs" company="">
//   
// </copyright>
// <summary>
//   The account service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Collections.Generic;
using Ojb.DataModules.Security.Contract.Domain;
using Ojb.DataModules.Security.Contract.Repository;
using Ojb.DomainServices.Contract.MessageModels.Response;
using Ojb.DomainServices.Contract.Services;
using Ojb.Framework.ServiceBase.Imps;

namespace Ojb.DomainServices.Library.ServiceImp
{
    using System.Linq;

    /// <summary>
    /// The account service.
    /// </summary>
    public class AccountService : ServiceBase, IAccountService
    {
        /// <summary>
        /// The security user repository.
        /// </summary>
        private readonly ISecurityRepository<User> SecurityUserRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountService"/> class.
        /// </summary>
        /// <param name="securityUserRepository">
        /// The security user repository.
        /// </param>
        public AccountService(ISecurityRepository<User> securityUserRepository)
        {
            this.SecurityUserRepository = securityUserRepository;
        }

        /// <summary>
        /// The get all account info.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        IEnumerable<AccountInfo> IAccountService.GetAllAccountInfo()
        {

            return new List<AccountInfo>
                {
                    new AccountInfo
                        {
                            Id = 1, 
                            FisrtName = "A", 
                            LastName = "B", 
                            Password = "123", 
                            PhoneNumber = "12345678", 
                            UserName = "a", 
                        }
                };
        }

        /// <summary>
        /// The get all account.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        IEnumerable<AccountInfo> IAccountService.GetAllAccount()
        {
            var users = this.SecurityUserRepository.GetAll();
            return users.Select(
                x => new AccountInfo 
                { 
                    UserName = x.UserName ,
                    Id = x.Id,
                    Password = x.Password
                }).ToList();
        }
    }
}