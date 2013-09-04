// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceResponse.cs" company="">
//   
// </copyright>
// <summary>
//   The service response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ojb.Framework.ServiceBase.MessageModels
{
    using System.Reflection;
    using System.Runtime.Serialization;

    /// <summary>
    /// The service response.
    /// </summary>
    [DataContract]
    public class ServiceResponse
    {
        /// <summary>
        ///     Build number of currently executing web service. Used as an indicator
        ///     to client whether certain code fixes are included or not.
        ///     Ebay.com uses this in their API.
        /// </summary>
        [DataMember] 
        public string Build =
            Assembly.GetExecutingAssembly().GetName().Version.Build.ToString();

        /// <summary>
        ///     Number of rows affected by "Create", "Update", or "Delete" action.
        /// </summary>
        [DataMember] 
        public int RowsAffected;

        /// <summary>
        ///     Number of rows before paged
        /// </summary>
        [DataMember] 
        public long TotalItemCount;

        /// <summary>
        /// The version.
        /// </summary>
        [DataMember] 
        public string Version =
            Assembly.GetExecutingAssembly().GetName().Version.Major + "." +
            Assembly.GetExecutingAssembly().GetName().Version.Minor;

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        [DataMember]
        public ResponseStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        [DataMember]
        public string Message { get; set; }
    }
}