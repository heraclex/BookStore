// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResponseStatus.cs" company="">
//   
// </copyright>
// <summary>
//   The response status.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Runtime.Serialization;

namespace Ojb.Framework.ServiceBase.MessageModels
{
    /// <summary>
    /// The response status.
    /// </summary>
    [DataContract]
    public enum ResponseStatus
    {
        /// <summary>
        /// The success.
        /// </summary>
        [EnumMember] 
        Success = 1, 

        /// <summary>
        /// The failure.
        /// </summary>
        [EnumMember] 
        Failure = 2, 

        /// <summary>
        /// The exception.
        /// </summary>
        [EnumMember] 
        Exception = 3
    }
}