namespace Aswig.Framework.EntityFrameworkProvider
{
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Data.Entity.Infrastructure;
    using System.Diagnostics;
    using Aswig.Framework.Common.Logger;

    using EFTracingProvider;

    public abstract class AswDbContext : System.Data.Entity.DbContext
    {
        #region private fields

        private enum CommandState { CommandExecuting = 1, CommandFailed = 2, CommandFinished = 3 };

        /// <summary>
        /// The max time allow per query execute.
        /// </summary>
        private const int MaxTimeAllowPerServiceMethod = 2000;

        /// <summary>
        /// Use StopWatch to calculate performance on each service method
        /// </summary>
        private readonly Stopwatch stopwatch = new Stopwatch();

        /// <summary>
        /// Log Wrapper to write down sql query tracing
        /// </summary>
        private readonly ILogger log = LogManager.GetLogger(typeof(DbContextCore));

        #endregion

        protected System.Data.Entity.DbSet DbSet { get; set; }

        protected AswDbContext(string connectionString) 
            : base(CreateTracingConnection(connectionString), true)
        {
            // Only for debug mode
            if (log.IsDebugEnabled)
            {
                var cx = ((IObjectContextAdapter)this).ObjectContext;
                cx.EnableTracing();

                IEnumerable<EFTracingConnection> traceConnections = cx.Connection.GetTracingConnections();
                var myList = new List<EFTracingConnection>(traceConnections);
                myList.ForEach(
                    c =>
                        {
                            c.CommandExecuting += (s, e) => LogSql(e, CommandState.CommandExecuting);
                            c.CommandFailed += (s, e) => LogSql(e, CommandState.CommandFailed);
                            c.CommandFinished += (s, e) => LogSql(e, CommandState.CommandFinished);
                        });
            }
        }

        /// <summary>
        /// The logging method.  Overwrite this method to change the logging strategy.
        /// </summary>
        /// <param name="e">The DB command event.</param>
        /// <param name="commState"> Command State </param>
        private void LogSql(CommandExecutionEventArgs e, CommandState commState)
        {
            switch (commState)
            {
                case CommandState.CommandExecuting:
                    stopwatch.Start();
                    log.InfoFormat(
                        "[Database: {0}] - Executing command {1}", e.Command.Connection.Database, e.ToTraceString());
                    break;
                case CommandState.CommandFailed:
                    stopwatch.Stop();
                    log.InfoFormat(
                        "[Database: {0}] - Executing command {1} was FAILED", e.Command.Connection.Database, e.ToTraceString());
                    break;
                case CommandState.CommandFinished:
                    stopwatch.Stop();
                    if (stopwatch.ElapsedMilliseconds > MaxTimeAllowPerServiceMethod)
                    {
                        log.WarnFormat("Execute for command take: [{0} ms], it is exceed 2s", stopwatch.ElapsedMilliseconds);
                    }
                    log.InfoFormat("Finished execute command. It takes: {0} millisecond", stopwatch.ElapsedMilliseconds);
                    break;
            }
        }

        /// <summary>
        /// Create Tracing Connection
        /// </summary>
        /// <param name="nameOrConnectionString">Name Or ConnectionString from app config</param>
        /// <returns>DbConnection obj</returns>
        private static DbConnection CreateTracingConnection(string nameOrConnectionString)
        {
            try
            {
                // this only supports entity connection strings http://msdn.microsoft.com/en-us/library/cc716756.aspx
                return EFTracingProviderUtils.CreateTracedEntityConnection(nameOrConnectionString);
            }
            catch (ArgumentException)
            {
                var providerName = "System.Data.SqlClient";
                return CreateTracingConnection(nameOrConnectionString, providerName);
            }
        }

        /// <summary>
        /// CreateTracingConnection with providerInvariantName
        /// </summary>
        /// <param name="connString"> Connection String </param>
        /// <param name="providerInvariantName">provider Invariant Name</param>
        /// <returns>EFTracingConnection obj</returns>
        private static EFTracingConnection CreateTracingConnection(string connString, string providerInvariantName)
        {
            // based on the example at http://jkowalski.com/2010/04/23/logging-sql-statements-in-entity-frameworkcode-first/
            var wrapperConnectionString =
                String.Format(@"wrappedProvider={0};{1}", providerInvariantName, connString);

            var connection = new EFTracingConnection { ConnectionString = wrapperConnectionString };

            return connection;
        }

    }
}
