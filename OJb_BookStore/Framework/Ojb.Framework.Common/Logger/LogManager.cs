// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogManager.cs" company="OjbSolution">
//   
// </copyright>
// <summary>
//   Defines the LogManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ojb.Framework.Common.Logger
{
    using System;

    /// <summary>
    /// Log Manager class
    /// </summary>
    public static class LogManager
    {
        #region public methods

        /// <summary>
        /// Get LogWrapper
        /// </summary>
        /// <param name="type">
        /// Type of class, namespace, assembly
        /// </param>
        /// <returns>
        /// Interface of LogWrapper
        /// </returns>
        public static ILogger GetLogger(Type type)
        {
            return new Logger(type);
        }

        /// <summary>
        /// Config For log4Net dll
        /// </summary>
        /// <param name="configFilePath">
        /// The config File name.
        /// </param>
        /// <param name="sendEmail">
        /// System will send email automatically when the error occur
        /// True: writing to log file and send mail for supporting, False: don't send email
        /// </param>
        public static void Initialize(string configFilePath = null, bool sendEmail = false)
        {
            var logger = new Logger(typeof(LogManager));
            logger.ConfigureTarget(configFilePath);
        }

        #endregion
    }
}
