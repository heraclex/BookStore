// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Logger.cs" company="OjbSolution">
//   
// </copyright>
// <summary>
//   Defines the LogWrapper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ojb.Framework.Common.Logger
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Text;

    using log4net;

    /// <summary>
    /// Logger wrapper
    /// </summary>
    internal class Logger : ILogger
    {
        #region private fields

        /// <summary>
        /// Ilog (log4Net) inteface
        /// </summary>
        private readonly ILog logger;

        /// <summary>
        /// check the log wrapper is initialized or not
        /// </summary>
        private static bool isInitialized;

        #endregion

        #region Contructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="serverMailInfo">
        /// The server Mail Info.
        /// </param>
        public Logger(Type type)
        {
            this.logger = log4net.LogManager.GetLogger(type);
        }

        #endregion

        #region Implementation of public properties
        
        /// <summary>
        /// Gets a value indicating whether IsDebugEnabled.
        /// </summary>
        public bool IsDebugEnabled
        {
            get
            {
                return this.logger.IsDebugEnabled;
            }
        }

        /// <summary>
        /// Gets a value indicating whether IsErrorEnabled.
        /// </summary>
        public bool IsErrorEnabled
        {
            get
            {
                return this.logger.IsErrorEnabled;
            }
        }

        /// <summary>
        /// Gets a value indicating whether IsFatalEnabled.
        /// </summary>
        public bool IsFatalEnabled
        {
            get
            {
                return this.logger.IsFatalEnabled;
            }
        }

        /// <summary>
        /// Gets a value indicating whether IsInfoEnabled.
        /// </summary>
        public bool IsInfoEnabled
        {
            get
            {
                return this.logger.IsInfoEnabled;
            }
        }

        /// <summary>
        /// Gets a value indicating whether IsWarnEnabled.
        /// </summary>
        public bool IsWarnEnabled
        {
            get
            {
                return this.logger.IsWarnEnabled;
            }
        }

        #endregion

        #region Implementation of ILogger

        /// <summary>
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void Debug(object message)
        {
            this.logger.Debug(message);
        }

        /// <summary>
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        public void Debug(object message, Exception exception)
        {
            this.logger.Debug(message, exception);
        }

        /// <summary>
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="arg0">
        /// The arg 0.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void DebugFormat(string format, object arg0)
        {
            this.logger.DebugFormat(format, arg0);
        }

        /// <summary>
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        public void DebugFormat(string format, params object[] args)
        {
            this.logger.DebugFormat(format, args);
        }

        /// <summary>
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            this.logger.DebugFormat(provider, format, args);
        }

        /// <summary>
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="arg0">
        /// The arg 0.
        /// </param>
        /// <param name="arg1">
        /// The arg 1.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void DebugFormat(string format, object arg0, object arg1)
        {
            this.logger.DebugFormat(format, arg0, arg1);
        }

        /// <summary>
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="arg0">
        /// The arg 0.
        /// </param>
        /// <param name="arg1">
        /// The arg 1.
        /// </param>
        /// <param name="arg2">
        /// The arg 2.
        /// </param>
        public void DebugFormat(string format, object arg0, object arg1, object arg2)
        {
            this.logger.DebugFormat(format, arg0, arg1, arg2);
        }

        /// <summary>
        /// Log Error
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void Error(object message)
        {
            this.logger.Error(message);
        }

        /// <summary>
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        public void Error(object message, Exception exception)
        {
            this.logger.Error(message, exception);
        }

        /// <summary>
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="arg0">
        /// The arg 0.
        /// </param>
        public void ErrorFormat(string format, object arg0)
        {
            this.logger.ErrorFormat(format, arg0);
        }

        /// <summary>
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        public void ErrorFormat(string format, params object[] args)
        {
            this.logger.ErrorFormat(format, args);
        }

        /// <summary>
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            this.logger.ErrorFormat(provider, format, args);
        }

        /// <summary>
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="arg0">
        /// The arg 0.
        /// </param>
        /// <param name="arg1">
        /// The arg 1.
        /// </param>
        public void ErrorFormat(string format, object arg0, object arg1)
        {
            this.logger.ErrorFormat(format, arg0, arg1);
        }

        /// <summary>
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="arg0">
        /// The arg 0.
        /// </param>
        /// <param name="arg1">
        /// The arg 1.
        /// </param>
        /// <param name="arg2">
        /// The arg 2.
        /// </param>
        public void ErrorFormat(string format, object arg0, object arg1, object arg2)
        {
            this.logger.ErrorFormat(format, arg0, arg1, arg2);
        }

        /// <summary>
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void Fatal(object message)
        {
            this.logger.Fatal(message);
        }

        /// <summary>
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        public void Fatal(object message, Exception exception)
        {
            this.logger.Fatal(message, exception);
        }

        /// <summary>
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="arg0">
        /// The arg 0.
        /// </param>
        public void FatalFormat(string format, object arg0)
        {
            this.logger.FatalFormat(format, arg0);
        }

        /// <summary>
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        public void FatalFormat(string format, params object[] args)
        {
            this.logger.FatalFormat(format, args);
        }

        /// <summary>
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        public void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            this.logger.FatalFormat(provider, format, args);
        }

        /// <summary>
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="arg0">
        /// The arg 0.
        /// </param>
        /// <param name="arg1">
        /// The arg 1.
        /// </param>
        public void FatalFormat(string format, object arg0, object arg1)
        {
            this.logger.FatalFormat(format, arg0, arg1);
        }

        /// <summary>
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="arg0">
        /// The arg 0.
        /// </param>
        /// <param name="arg1">
        /// The arg 1.
        /// </param>
        /// <param name="arg2">
        /// The arg 2.
        /// </param>
        public void FatalFormat(string format, object arg0, object arg1, object arg2)
        {
            this.logger.FatalFormat(format, arg0, arg1, arg2);
        }

        /// <summary>
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void Info(object message)
        {
            this.logger.Info(message);
        }

        /// <summary>
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        public void Info(object message, Exception exception)
        {
            this.logger.Info(message, exception);
        }

        /// <summary>
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="arg0">
        /// The arg 0.
        /// </param>
        public void InfoFormat(string format, object arg0)
        {
            this.logger.InfoFormat(format, arg0);
        }

        /// <summary>
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        public void InfoFormat(string format, params object[] args)
        {
            this.logger.InfoFormat(format, args);
        }

        /// <summary>
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        public void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            this.logger.InfoFormat(provider, format, args);
        }

        /// <summary>
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="arg0">
        /// The arg 0.
        /// </param>
        /// <param name="arg1">
        /// The arg 1.
        /// </param>
        public void InfoFormat(string format, object arg0, object arg1)
        {
            this.logger.InfoFormat(format, arg0, arg1);
        }

        /// <summary>
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="arg0">
        /// The arg 0.
        /// </param>
        /// <param name="arg1">
        /// The arg 1.
        /// </param>
        /// <param name="arg2">
        /// The arg 2.
        /// </param>
        public void InfoFormat(string format, object arg0, object arg1, object arg2)
        {
            this.logger.InfoFormat(format, arg0, arg1, arg2);
        }

        /// <summary>
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void Warn(object message)
        {
            this.logger.Warn(message);
        }

        /// <summary>
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        public void Warn(object message, Exception exception)
        {
            this.logger.Warn(message, exception);
        }

        /// <summary>
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="arg0">
        /// The arg 0.
        /// </param>
        public void WarnFormat(string format, object arg0)
        {
            this.logger.WarnFormat(format, arg0);
        }

        /// <summary>
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        public void WarnFormat(string format, params object[] args)
        {
            this.logger.WarnFormat(format, args);
        }

        /// <summary>
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        public void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            this.logger.WarnFormat(provider, format, args);
        }

        /// <summary>
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="arg0">
        /// The arg 0.
        /// </param>
        /// <param name="arg1">
        /// The arg 1.
        /// </param>
        public void WarnFormat(string format, object arg0, object arg1)
        {
            this.logger.WarnFormat(format, arg0, arg1);
        }

        /// <summary>
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="arg0">
        /// The arg 0.
        /// </param>
        /// <param name="arg1">
        /// The arg 1.
        /// </param>
        /// <param name="arg2">
        /// The arg 2.
        /// </param>
        public void WarnFormat(string format, object arg0, object arg1, object arg2)
        {
            this.logger.WarnFormat(format, arg0, arg1, arg2);
        }

        #endregion

        #region Cutom Log Implementation

        public void LogException(string message, Exception exception)
        {
            this.LogExceptionCore(message, exception);
        }

        #endregion

        #region Configuration Methods

        /// <summary>
        /// Config Log filename
        /// </summary>
        /// <param name="configFilePath">
        /// The config File Path.
        /// </param>
        public void ConfigureTarget(string configFilePath)
        {
            if (!isInitialized)
            {
                if (!string.IsNullOrEmpty(configFilePath))
                {
                    log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(configFilePath));
                }
                else
                {
                    log4net.Config.XmlConfigurator.Configure();
                }

                isInitialized = true;
            }
            else
            {
                throw new Exception("Logging has already been initialized.");
            }
        }

        #endregion

        #region Private Methods

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
        private string BuildFormattedMessageForException(
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
        private void LogExceptionCore(string message, Exception exception)
        {
            // Using the StackTrace object to know correct calling method, with GetFrame(2) because
            // Calling method (2) -> LogException(1) -> LogExceptionCore(0)
            var stackTrace = new StackTrace();
            MemberInfo prevMethodInfo = stackTrace.GetFrame(2).GetMethod();
            Type callertype = prevMethodInfo.ReflectedType;
            logger.Error(this.BuildFormattedMessageForException(message, exception, callertype.Assembly));
        }

        #endregion
    }
}
