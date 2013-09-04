// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResponseBase.cs" company="">
//   
// </copyright>
// <summary>
//   The response base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace Ojb.Framework.ServiceBase.MessageModels
{
    /// <summary>
    /// The response base.
    /// </summary>
    [DataContract]
    public class ResponseBase
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
        ///     CorrelationId mostly returns the RequestId back to client.
        /// </summary>
        [DataMember] 
        public string CorrelationId;

        /// <summary>
        ///     if create/update/delete success return true
        /// </summary>
        [DataMember] 
        public bool IsSsucceed;

        /// <summary>
        ///     Message back to client. Mostly used when a web service failure occurs.
        /// </summary>
        [DataMember] 
        public string Message;

        /// <summary>
        ///     Date when reservation number expires.
        /// </summary>
        [DataMember] 
        public DateTime ReservationExpires;

        /// <summary>
        ///     Reservation number issued by the web service. Used in long running requests.
        ///     Also sometimes referred to as Correlation Id. This number is a way for both the client
        ///     and web service to keep track of long running requests (for example, a request
        ///     to make a reservation for a airplane flight).
        /// </summary>
        [DataMember] 
        public string ReservationId;

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
        ///     Version number (in major.minor format) of currently executing web service.
        ///     Used to offer a level of understanding (related to compatibility issues) between
        ///     the client and the web service as the web services evolve over time.
        ///     Ebay.com uses this in their API.
        /// </summary>
        [DataMember] 
        public string Version =
            Assembly.GetExecutingAssembly().GetName().Version.Major + "." +
            Assembly.GetExecutingAssembly().GetName().Version.Minor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseBase"/> class. 
        ///     Default Constructor for ResponseBase.
        /// </summary>
        public ResponseBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseBase"/> class. 
        /// Overloaded Constructor for ResponseBase.
        ///     Sets CorrelationId from incoming Request.
        /// </summary>
        /// <param name="correlationId">
        /// The correlation identifier for request and response.
        /// </param>
        public ResponseBase(string correlationId)
        {
            this.CorrelationId = correlationId;
        }
    }
}