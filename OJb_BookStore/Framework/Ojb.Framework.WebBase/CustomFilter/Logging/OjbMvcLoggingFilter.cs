namespace Ojb.Framework.WebBase.CustomFilter.Logging
{
    using System;
    using System.Web.Mvc;

    using Ojb.Framework.Common.Logger;

    /// <summary>
    /// The cx mvc logging filter.
    /// </summary>
    public class OjbMvcLoggingFilter : ActionFilterAttribute
    {
        #region Constants

        /// <summary>
        /// The max time allow per action.
        /// </summary>
        private const int MaxTimeAllowPerAction = 3000;

        #endregion

        #region Static Fields

        /// <summary>
        /// The action performance key.
        /// </summary>
        private static readonly object ActionPerformanceKey = new object();

        /// <summary>
        /// Logger for logging.
        /// </summary>
        private static readonly ILogger Log = LogManager.GetLogger(typeof(OjbMvcLoggingFilter));

        #endregion

        #region Log Info

        /// <summary>
        /// End Log Action per request from client
        /// </summary>
        /// <param name="filterContext">
        /// Filter of content
        /// </param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var startRequest = (DateTime)filterContext.HttpContext.Items[ActionPerformanceKey];

            TimeSpan duration = DateTime.Now - startRequest;
            if (duration.Milliseconds > MaxTimeAllowPerAction)
            {
                Log.WarnFormat(
                    "Process for action [{0}.{1}] take: [{2} ms], it is exceed 3s",
                    filterContext.Controller.GetType(),
                    filterContext.ActionDescriptor.ActionName,
                    duration.Milliseconds);
            }

            Log.InfoFormat(
                    "End controller {0}, action {1}. It takes: {2} millisecond",
                    filterContext.Controller.GetType(),
                    filterContext.ActionDescriptor.ActionName,
                    duration.Milliseconds);

            base.OnActionExecuted(filterContext);
        }

        /// <summary>
        /// Start Log Action per request from client
        /// </summary>
        /// <param name="filterContext">
        /// Filter of content
        /// </param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log.Info(
                string.Format(
                    "Start controller {0}, action {1}",
                    filterContext.Controller.GetType(),
                    filterContext.ActionDescriptor.ActionName));

            // Store current datetime to calculate performance on each action
            filterContext.HttpContext.Items[ActionPerformanceKey] = DateTime.Now;

            base.OnActionExecuting(filterContext);
        }

        #endregion
    }
}
