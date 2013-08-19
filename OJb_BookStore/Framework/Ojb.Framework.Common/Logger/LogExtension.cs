namespace Aswig.Framework.Common.Logger
{
    #region

    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Reflection;
    using System.Text;

    using log4net;

    #endregion

    /// <summary>
    ///   The log4Net extension methods.
    /// </summary>
    public static class LogExtension
    {
        #region Public Methods and Operators

        /// <summary>
        /// Log debug message with lazy message message provider.
        /// </summary>
        /// <param name="messageProvider">
        /// The lazy message provider. 
        /// </param>
        public static void Debug(this ILog log, Func<string> messageProvider)
        {
            if (log.IsDebugEnabled)
            {
                log.Debug(messageProvider());
            }
        }

        /// <summary>
        /// Log error message with lazy message message provider.
        /// </summary>
        /// <param name="messageProvider">
        /// The lazy message provider. 
        /// </param>
        public static void Error(this ILog log, Func<string> messageProvider)
        {
            if (log.IsErrorEnabled)
            {
                log.Error(messageProvider());
            }
        }

        /// <summary>
        /// Log fatal message with lazy message message provider.
        /// </summary>
        /// <param name="messageProvider">
        /// The lazy message provider. 
        /// </param>
        public static void Fatal(this ILog log, Func<string> messageProvider)
        {
            if (log.IsFatalEnabled)
            {
                log.Fatal(messageProvider());
            }
        }

        /// <summary>
        /// Log info message with lazy message message provider.
        /// </summary>
        /// <param name="messageProvider">
        /// The lazy message provider. 
        /// </param>
        public static void Info(this ILog log, Func<string> messageProvider)
        {
            if (log.IsInfoEnabled)
            {
                log.Info(messageProvider());
            }
        }

        /// <summary>
        /// Log detail exception.
        /// </summary>
        /// <param name="exception">
        /// The exception to log. 
        /// </param>
        public static void LogException(this ILog log, Exception exception)
        {
            LogExceptionCore(log, null, exception);
        }

        /// <summary>
        /// Log an detail exception with message.
        /// </summary>
        /// <param name="message">
        /// The message. 
        /// </param>
        /// <param name="exception">
        /// The exception to log. 
        /// </param>
        public static void LogException(this ILog log, string message, Exception exception)
        {
            LogExceptionCore(log, message, exception);
        }

        /// <summary>
        /// Log warn message with lazy message message provider.
        /// </summary>
        /// <param name="messageProvider">
        /// The lazy message provider. 
        /// </param>
        public static void Warn(this ILog log, Func<string> messageProvider)
        {
            if (log.IsWarnEnabled)
            {
                log.Warn(messageProvider());
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Build formatted message for an exception.
        /// </summary>
        /// <param name="message">
        /// The message to explain about the exception. 
        /// </param>
        /// <param name="exception">
        /// The exception to parse for data. 
        /// </param>
        /// <param name="assembly">
        /// The assembly of the caller. 
        /// </param>
        /// <param name="showStack">
        /// The flag indicating that we need to show full stack trace or not 
        /// </param>
        /// <returns>
        /// The formatted message for an exception. 
        /// </returns>
        private static string BuildFormattedMessageForException(
            string message, Exception exception, Assembly assembly, bool showStack = true)
        {
            if (message == null)
            {
                message = exception.Message;
            }

            const string TextSeparator = "*********************************************";

            // Create StringBuilder to maintain publishing information.
            var strInfo =
                new StringBuilder(
                    Environment.NewLine + Environment.NewLine + message + Environment.NewLine + Environment.NewLine);
            try
            {
                if (exception != null)
                {
                    // Loop through each exception class in the chain of exception objects.

                    // Temp variable to hold BaseApplicationException object during the loop.
                    Exception currentException = exception;
                    int intExceptionCount = 1; // Count variable to track the number of exceptions in the chain.
                    do
                    {
                        // Write title information for the exception object.
                        strInfo.AppendFormat(
                            "{1}) Exception Information{0}{2}",
                            Environment.NewLine,
                            intExceptionCount.ToString(CultureInfo.InvariantCulture),
                            TextSeparator);
                        strInfo.AppendFormat(
                            "{0}Exception Type: {1}", Environment.NewLine, currentException.GetType().FullName);

                        // Loop through the public properties of the exception object and record their value.
                        PropertyInfo[] aryPublicProperties = currentException.GetType().GetProperties();
                        foreach (PropertyInfo p in aryPublicProperties)
                        {
                            // Do not log information for the InnerException or StackTrace. This information is 
                            // captured later in the process.
                            if ((!p.Name.Equals("InnerException") && !p.Name.Equals("StackTrace"))
                                && !p.Name.Equals("BaseInnerException"))
                            {
                                object prop = null;
                                try
                                {
                                    prop = p.GetValue(currentException, null);
                                }
                                catch (TargetInvocationException)
                                {
                                    // We don't expect exception here so just ignore it.
                                }

                                if (prop == null)
                                {
                                    strInfo.AppendFormat("{0}{1}: NULL", Environment.NewLine, p.Name);
                                }
                                else if (p.Name.Equals("Data"))
                                {
                                    // Loop all data in Data property
                                    strInfo.AppendFormat("{0}Data:", Environment.NewLine);
                                    foreach (object datakey in currentException.Data.Keys)
                                    {
                                        strInfo.AppendFormat(
                                            "{0}{1}: {2}", Environment.NewLine, datakey, currentException.Data[datakey]);
                                    }
                                }
                                else if (p.PropertyType.IsArray)
                                {
                                    // If property is array, it will loop all item in array
                                    strInfo.AppendFormat("{0}{1}:", Environment.NewLine, p.Name);
                                    var array = (Array)prop;
                                    foreach (object aryPublicProperty in array)
                                    {
                                        strInfo.AppendFormat("{0}{1}", Environment.NewLine, aryPublicProperty);
                                    }
                                }
                                else
                                {
                                    strInfo.AppendFormat("{0}{1}: {2}", Environment.NewLine, p.Name, prop);
                                }
                            }
                        }

                        if (showStack && (currentException.StackTrace != null))
                        {
                            strInfo.AppendFormat(
                                "{0}{0}2) StackTrace Information{0}{1}",
                                Environment.NewLine,
                                TextSeparator);
                            strInfo.AppendFormat("{0}{1}", Environment.NewLine, currentException.StackTrace);
                        }

                        strInfo.AppendFormat("{0}", Environment.NewLine);
                        currentException = currentException.InnerException;
                        intExceptionCount++;
                    }
                    while (currentException != null);
                }

                strInfo.AppendFormat(
                    "{0}3) Assembly Information:{0}{1}{0}Assembly name: {2}{0}Assembly version: {3}{0}RuntimeVersion: {4}{0}",
                    Environment.NewLine,
                    TextSeparator,
                    assembly.GetName(),
                    assembly.GetName().Version,
                    assembly.ImageRuntimeVersion);
            }
            catch (Exception ex)
            {
                strInfo.AppendFormat(
                    "{0}{0}Exception in PublishException:{4}{0}{1}{0}Original message:{0}{2}{0}Original Exception:{0}{3}",
                    Environment.NewLine,
                    ex.Message,
                    message,
                    exception.Message,
                    TextSeparator);
            }

            return strInfo.ToString();
        }

        /// <summary>
        /// Core Log an exception with message, this method will help get correct calling assembly.
        /// </summary>
        /// <param name="exception">
        /// The exception to log. 
        /// </param>
        private static void LogExceptionCore(ILog log, string message, Exception exception)
        {
            // Using the StackTrace object to know correct calling method, with GetFrame(2) because
            // Calling method (2) -> LogException(1) -> LogExceptionCore(0)
            var stackTrace = new StackTrace();
            MemberInfo prevMethodInfo = stackTrace.GetFrame(2).GetMethod();
            Type callertype = prevMethodInfo.ReflectedType;
            log.Error(() => BuildFormattedMessageForException(message, exception, callertype.Assembly));
        }

        #endregion
    }
}
