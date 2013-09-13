namespace Ojb.Framework.Common.Exception
{
    using System;
    using System.Runtime.Serialization;

    public class OjbException : Exception
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref = "OjbException" /> class.
        /// </summary>
        public OjbException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OjbException"/> class.
        /// </summary>
        public OjbException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OjbException"/> class.
        /// </summary>
        public OjbException(string message, Exception rootCause)
            : base(message, rootCause)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OjbException"/> class.
        /// </summary>
        /// <param name="info">
        /// The serialization information that holds 
        /// the serialized object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The context that contains contextual information about the source or destination.
        /// </param>
        public OjbException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion
    }
}
