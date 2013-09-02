// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Product.cs" company="">
//   
// </copyright>
// <summary>
//   The product.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System.ComponentModel.DataAnnotations;
using Ojb.Framework.Domain.Entity;

namespace Ojb.DataModules.Product.Contract.Domain
{
    /// <summary>
    /// The product.
    /// </summary>
    public class Product : AuditEntity
    {
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        public virtual Category Category { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Gets or sets the image path.
        /// </summary>
        public virtual string ImagePath { get; set; }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        [DataType(DataType.Currency)]
        public virtual decimal UnitPrice { get; set; }
    }
}