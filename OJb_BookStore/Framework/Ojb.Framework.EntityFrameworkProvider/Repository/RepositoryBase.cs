// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoryBase.cs" company="">
//   
// </copyright>
// <summary>
//   The repository base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using Ojb.Framework.Domain.Interfaces;
using Ojb.Framework.EntityFrameworkProvider.DbContext;

namespace Ojb.Framework.EntityFrameworkProvider.Repository
{
    /// <summary>
    /// The repository base.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class RepositoryBase<T> : RepositoryWithTypedId<T, int>, IRepositoryBase<T>
        where T : class, IEntityWithTypedId<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase{T}"/> class.
        /// </summary>
        /// <param name="dbContext">
        /// The db context.
        /// </param>
        public RepositoryBase(System.Data.Entity.DbContext dbContext) : base(dbContext)
        {
        }
    }

    /// <summary>
    /// The repository with typed id.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    /// <typeparam name="TId">
    /// </typeparam>
    public class RepositoryWithTypedId<T, TId> : IRepositoryWithTypedId<T, TId> where T : class, IEntityWithTypedId<TId>
    {
        /// <summary>
        /// The _db context.
        /// </summary>
        private readonly System.Data.Entity.DbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryWithTypedId{T,TId}"/> class.
        /// </summary>
        /// <param name="dbContext">
        /// The db context.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Argument Null Exception
        /// </exception>
        public RepositoryWithTypedId(System.Data.Entity.DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("dbContext may not be null");
            }

            this._dbContext = dbContext;
            this.Includes = new Collection<string>();
        }

        /// <summary>
        /// Gets the selected set with includes.
        /// </summary>
        private DbQuery<T> SelectedSetWithIncludes
        {
            get
            {
                DbQuery<T> query = _dbContext.Set<T>();

                foreach (string include in Includes)
                {
                    query = (DbQuery<T>) query.Include<T>(include);
                }

                return query;
            }
        }

        /// <summary>
        /// Gets or sets the includes.
        /// </summary>
        private Collection<string> Includes { get; set; }

        #region public properties

        /// <summary>
        /// Gets the db context.
        /// </summary>
        public virtual IDbContextCore DbContext
        {
            get { return new DbContextCore(_dbContext); }
        }

        #endregion

        #region public methods

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public virtual T Get(TId id)
        {
            return SelectedSetWithIncludes.AsEnumerable().Single(entity => id.Equals(entity.Id));
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public virtual IQueryable<T> GetAll()
        {
            return SelectedSetWithIncludes;
        }

        /// <summary>
        /// The save or update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public virtual T SaveOrUpdate(T entity)
        {
            if (entity == null)
                return null;

            if (entity.IsTransient())
                _dbContext.Set<T>().Add(entity);

            // _dbContext.SaveChanges();
            return entity;
        }

        /// <summary>
        /// This deletes the object and commits the deletion immediately.  We don't want to delay deletion
        ///     until a transaction commits, as it may throw a foreign key constraint exception which we could
        ///     likely handle and inform the user about.  Accordingly, this tries to delete right away; if there
        ///     is a foreign key constraint preventing the deletion, an exception will be thrown.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public virtual void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Include all sub table names, so when we executing the query,
        ///     it will be automatically get all data from sub-tables as well
        /// </summary>
        /// <param name="subTableName">
        /// The sub Table Name.
        /// </param>
        /// <returns>
        /// The <see cref="IRepositoryWithTypedId"/>.
        /// </returns>
        public IRepositoryWithTypedId<T, TId> Include(string subTableName)
        {
            Includes.Add(subTableName);

            return this;
        }

        /// <summary>
        /// Query method will return IQueryable to Repository.
        /// </summary>
        /// <param name="where">
        /// Where condition on Entity.
        /// </param>
        /// <typeparam name="T">
        /// T Entity : conrete class
        /// </typeparam>
        /// <returns>
        /// IQueryable base on T Entity
        /// </returns>
        public IQueryable<T> Query<T>(Expression<Func<T, bool>> @where)
        {
            return ((IQueryable<T>) _dbContext.Set(typeof (T))).Where(@where);
        }

        /// <summary>
        /// The delete by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public virtual void DeleteById(TId id)
        {
            object entity = _dbContext.Set(typeof (T)).Find(id);
            if (entity != null)
            {
                _dbContext.Set<T>().Remove((T) entity);
                _dbContext.SaveChanges();
            }
        }

        #endregion
    }
}