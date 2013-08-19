// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISecurityRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The SecurityRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Ojb.Framework.Domain.Interfaces;

namespace Ojb.DataModules.Security.Contract.Repository
{
    /// <summary>
    /// The SecurityRepository interface.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface ISecurityRepository<T> : IRepositoryBase<T> where T : class
    {

    }
}