namespace Aswig.Framework.EntityFrameworkProvider
{
    using System;
    using System.Data;
    using System.Data.Common;
    using System.Diagnostics;

    using Aswig.Framework.Common.Logger;
    using Aswig.Framework.Domain.Interfaces;

    using EFTracingProvider;

    public class DbContextCore : IDbContextCore
    {
        public DbContextCore(System.Data.Entity.DbContext dbContext)
        {
            if (dbContext == null) throw new ArgumentNullException("dbContext may not be null");

            this.dbContext = dbContext;
            this.ConfigDbContext();
        }

        public virtual IDisposable BeginTransaction()
        {
            transaction = dbContext.Database.Connection.BeginTransaction();
            return transaction;
        }

        /// <summary>
        /// This isn't specific to any one DAO and flushes everything that has been
        /// changed since the last commit.
        /// </summary>
        public virtual void CommitChanges()
        {
            dbContext.SaveChanges();
        }

        public virtual void CommitTransaction()
        {
            if (transaction != null)
                transaction.Commit();
        }

        public virtual void RollbackTransaction()
        {
            if (transaction == null)
            {
                throw new ApplicationException("Cannot roll back a transaction while there is no transaction running.");
            }

            transaction.Rollback();
            this.ReleaseCurrentTransaction();
        }

        public void Dispose()
        {
            if (dbContext != null && dbContext.Database.Connection.State == ConnectionState.Open) ;
            {
                dbContext.Database.Connection.Close();
            }

            GC.SuppressFinalize(this); 
        }

        #region private methods

        /// <summary>
        /// Releases the current transaction
        /// </summary>
        private void ReleaseCurrentTransaction()
        {
            if (transaction != null)
            {
                transaction.Dispose();
                transaction = null;
            }
        }

        /// <summary>
        /// DbContext Configuration method
        /// </summary>
        private void ConfigDbContext()
        {
            this.dbContext.Configuration.LazyLoadingEnabled = true;
            this.dbContext.Configuration.ProxyCreationEnabled = true;
            this.dbContext.Configuration.AutoDetectChangesEnabled = false;
        }

        #endregion

        private static IDbTransaction transaction;
        private readonly System.Data.Entity.DbContext dbContext;
    }
}