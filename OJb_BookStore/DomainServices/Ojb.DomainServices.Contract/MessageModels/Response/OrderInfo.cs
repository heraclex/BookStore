// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderInfo.cs" company="">
//   
// </copyright>
// <summary>
//   The order info.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Runtime.Serialization;
using Ojb.Framework.ServiceBase.MessageModels;

namespace Ojb.DomainServices.Contract.MessageModels.Response
{
    /// <summary>
    /// The order info.
    /// </summary>
    [DataContract]
    public class OrderInfo : ResponseBase
    {
        /// <summary>
        /// The customer address.
        /// </summary>
        [DataMember] public string CustomerAddress;

        /// <summary>
        /// The customer name.
        /// </summary>
        [DataMember] public string CustomerName;

        /// <summary>
        /// The customer phone number.
        /// </summary>
        [DataMember] public string CustomerPhoneNumber;

        /// <summary>
        /// The id.
        /// </summary>
        [DataMember] public int Id;
    }
}