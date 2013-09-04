// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeInfo.cs" company="">
//   
// </copyright>
// <summary>
//   The employee info.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Runtime.Serialization;
using Ojb.Framework.ServiceBase.MessageModels;

namespace Ojb.DomainServices.Contract.MessageModels.Response
{
    /// <summary>
    /// The employee info.
    /// </summary>
    [DataContract]
    public class EmployeeInfo : ResponseBase
    {
        /// <summary>
        /// The fisrt name.
        /// </summary>
        [DataMember] 
        public string FisrtName;

        /// <summary>
        /// The id.
        /// </summary>
        [DataMember] 
        public int Id;

        /// <summary>
        /// The last name.
        /// </summary>
        [DataMember] 
        public string LastName;

        /// <summary>
        /// The password.
        /// </summary>
        [DataMember] 
        public string Password;

        /// <summary>
        /// The phone number.
        /// </summary>
        [DataMember] 
        public string PhoneNumber;

        /// <summary>
        /// The user name.
        /// </summary>
        [DataMember] 
        public string UserName;
    }
}