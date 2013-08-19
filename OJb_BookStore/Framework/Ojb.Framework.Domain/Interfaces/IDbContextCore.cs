using System;

namespace Ojb.Framework.Domain.Interfaces
{
    /// <summary>
    /// Note that outside of CommitChanges(), you shouldn't have to invoke this object very often.
    /// If you're using the NHibernateSessionModule HttpModule, then the transaction 
    /// opening/committing will be taken care of for you.
    /// </summary>
    public interface IDbContextCore : IDisposable
    {
        IDisposable BeginTransaction();
        void CommitChanges();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
