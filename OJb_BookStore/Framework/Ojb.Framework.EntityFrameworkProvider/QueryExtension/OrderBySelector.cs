namespace Ojb.Framework.EntityFrameworkProvider.QueryExtension
{
    #region

    using System;
    using System.Linq.Expressions;

    #endregion

    /// <summary>
    /// Data structure for a property selector in an order by clause.
    /// </summary>
    /// <typeparam name="TEntity">
    /// The entity type.
    /// </typeparam>
    public struct OrderBySelector<TEntity>
    {
        #region Fields

        /// <summary>
        /// Flag indicate it is a descending order.
        /// </summary>
        public bool Descending;

        /// <summary>
        /// The property selector.
        /// </summary>
        public Expression<Func<TEntity, object>> Selector;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderBySelector{TEntity}"/> struct.
        /// </summary>
        /// <param name="desc">
        /// Flag indicate it is descending order.
        /// </param>
        /// <param name="selector">
        /// The property selector.
        /// </param>
        public OrderBySelector(bool desc, Expression<Func<TEntity, object>> selector)
        {
            this.Descending = desc;
            this.Selector = selector;
        }

        #endregion
    }
}
