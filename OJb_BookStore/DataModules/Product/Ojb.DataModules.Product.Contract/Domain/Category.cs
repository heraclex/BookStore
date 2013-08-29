// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Category.cs" company="">
//   
// </copyright>
// <summary>
//   The category.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Collections.Generic;
using Ojb.Framework.Domain.Entity;

namespace Ojb.DataModules.Product.Contract.Domain
{
    /// <summary>
    /// The category.
    /// </summary>
    public class Category : AuditEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class.
        /// </summary>
        public Category()
        {
            this.Products = new List<Product>();
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        public virtual IList<Product> Products { get; set; }
    }
}