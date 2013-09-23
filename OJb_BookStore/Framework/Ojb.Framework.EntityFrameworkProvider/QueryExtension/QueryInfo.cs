namespace Ojb.Framework.EntityFrameworkProvider.QueryExtension
{
    
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    #endregion

    /// <summary>
    /// Data structure to model a query for a list of entities.
    /// </summary>
    /// <typeparam name="TEntity">
    /// The entity type
    /// </typeparam>
    public class QueryInfo<TEntity>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryInfo{TEntity}"/> class.
        /// </summary>
        //public QueryInfo()
        //{
        //    this.EffectiveFilter = EffectiveFilter.All;
        //}

        #endregion

        #region Public Properties

        /// <summary>
        ///  Gets or sets EffectiveFilter: Current, Expired, Future and All.
        /// </summary>
        // public EffectiveFilter EffectiveFilter { get; set; }

        /// <summary>
        /// Gets or sets list of eagerly fetch property selectors.
        /// </summary>
        public List<Expression<Func<TEntity, object>>> Fetch { get; set; }

        /// <summary>
        /// Gets or sets list of order by selectors for order by clause.
        /// </summary>
        public IList<OrderBySelector<TEntity>> OrderBy { get; set; }

        /// <summary>
        ///  Gets or sets expression to pre-present the where clause.
        /// </summary>
        public Expression<Func<TEntity, bool>> Where { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Fluently add an ascending order by entry.
        /// </summary>
        /// <param name="propExp">
        /// The where clause.
        /// </param>
        /// <returns>
        /// This object for chain calling.
        /// </returns>
        public QueryInfo<TEntity> Asc(Expression<Func<TEntity, object>> propExp)
        {
            if (this.OrderBy == null)
            {
                this.OrderBy = new List<OrderBySelector<TEntity>>(1);
            }

            this.OrderBy.Add(new OrderBySelector<TEntity>(false, propExp));
            return this;
        }

        /// <summary>
        /// Fluently add an descending order by entry.
        /// </summary>
        /// <param name="propExp">
        /// The property to add.
        /// </param>
        /// <returns>
        /// This object for chain calling.
        /// </returns>
        public QueryInfo<TEntity> Desc(Expression<Func<TEntity, object>> propExp)
        {
            if (this.OrderBy == null)
            {
                this.OrderBy = new List<OrderBySelector<TEntity>>(1);
            }

            this.OrderBy.Add(new OrderBySelector<TEntity>(true, propExp));
            return this;
        }

        /// <summary>
        /// Fluently add a property to eagerly fetch list.
        /// </summary>
        /// <param name="propExp">
        /// The property to add.
        /// </param>
        /// <returns>
        /// This object for chain calling.
        /// </returns>
        public QueryInfo<TEntity> EagerLoad(Expression<Func<TEntity, object>> propExp)
        {
            if (this.Fetch == null)
            {
                this.Fetch = new List<Expression<Func<TEntity, object>>>(1);
            }

            this.Fetch.Add(propExp);
            return this;
        }

        /// <summary>
        /// Fluently add the where clause.
        /// </summary>
        /// <param name="whereExp">
        /// The where clause.
        /// </param>
        /// <returns>
        /// This object for chain calling.
        /// </returns>
        public QueryInfo<TEntity> Find(Expression<Func<TEntity, bool>> whereExp)
        {
            this.Where = whereExp;
            return this;
        }

        /// <summary>
        /// Fluently set the effective filter model.
        /// </summary>
        /// <param name="effective">
        /// The effective filter mode.
        /// </param>
        /// <returns>
        /// This object for chain calling.
        /// </returns>
        //public QueryInfo<TEntity> Effective(EffectiveFilter effective)
        //{
        //    this.EffectiveFilter = effective;
        //    return this;
        //}

        #endregion
    }
}
