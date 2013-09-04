// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserManager.cs" company="">
//   
// </copyright>
// <summary>
//   The user manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Ojb.DataModules.Security.Contract.Domain;
using Ojb.DataModules.Security.Contract.Repository;
using Ojb.DomainServices.Contract.MessageModels.Response;

namespace Ojb.DomainServices.Library.Managers
{
    /// <summary>
    ///     The user manager.
    /// </summary>
    internal class UserManager
    {
        /// <summary>
        /// The user repository.
        /// </summary>
        private readonly ISecurityRepository<User> UserRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserManager"/> class.
        /// </summary>
        /// <param name="UserRepository">
        /// The user repository.
        /// </param>
        public UserManager(ISecurityRepository<User> UserRepository)
        {
            this.UserRepository = UserRepository;
        }

        /// <summary>
        /// The get all acc info.
        /// </summary>
        /// <returns>
        /// The <see cref="AccountInfo"/>.
        /// </returns>
        public AccountInfo GetAllAccInfo()
        {
            using (var context = this.UserRepository.DbContext)
            {
                var aaa = this.UserRepository.GetAll();
            }
            return null;
        }
    }
}