// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequestBase.cs" company="">
//   
// </copyright>
// <summary>
//   The request base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Runtime.Serialization;

namespace Ojb.Framework.ServiceBase.MessageModels
{
    /// <summary>
    /// The request base.
    /// </summary>
    [DataContract]
    public class RequestBase
    {
        /// <summary>
        /// Gets or sets the token key.
        /// </summary>
        [DataMember]
        public string TokenKey { get; set; }
    }
}