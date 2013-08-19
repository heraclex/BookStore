// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CastleLogCallInterceptor.cs" company="OjbSolutions">
//   
// </copyright>
// <summary>
//   Log when call method for performance measurement purpose.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebApp.CastleConfiguration
{

    using System.Diagnostics;
    using System.IO;

    using Ojb.Framework.Common.Logger;

    using Castle.DynamicProxy;
    

    /// <summary>
    /// Log when call method for performance measurement purpose.
    /// </summary>
    public class CastleLogCallInterceptor : IInterceptor
    {
        #region Constants

        /// <summary>
        /// The max time allow per action.
        /// </summary>
        private const int MaxTimeAllowPerServiceMethod = 2000;

        #endregion

        #region Static Fields

        /// <summary>
        /// Logger for logging.
        /// </summary>
        private static readonly ILogger Log = LogManager.GetLogger(typeof(CastleLogCallInterceptor));

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Intercept the call
        /// </summary>
        /// <param name="invocation">The invocation object.</param>
        public void Intercept(IInvocation invocation)
        {
            if (invocation.Method == null || invocation.Method.DeclaringType == null)
            {
                return;
            }

            string className = invocation.Method.DeclaringType.Name;
            string methodName = invocation.Method.Name;
            Log.InfoFormat("Start call service method: {0}.{1}", className, methodName);

            // Use StopWatch to calculate performance on each service method
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            invocation.Proceed();

            stopwatch.Stop();
            if (stopwatch.ElapsedMilliseconds > MaxTimeAllowPerServiceMethod)
            {
                Log.WarnFormat(
                    "Process for service method [{0}.{1}] take: [{2} ms], it is exceed 2s",
                    className,
                    methodName,
                    stopwatch.ElapsedMilliseconds);
            }

            Log.InfoFormat(
                "End call service method: {0}.{1}. It takes: {2} millisecond",
                className,
                methodName,
                stopwatch.ElapsedMilliseconds);
        }

        #endregion
    }
}