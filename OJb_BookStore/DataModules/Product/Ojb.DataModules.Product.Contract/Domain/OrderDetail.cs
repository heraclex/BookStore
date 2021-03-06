﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderDetail.cs" company="">
//   
// </copyright>
// <summary>
//   The order detail.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System.ComponentModel.DataAnnotations;
using Ojb.Framework.Domain.Entity;

namespace Ojb.DataModules.Product.Contract.Domain
{
    /// <summary>
    /// The order detail.
    /// </summary>
    public class OrderDetail : AuditEntity
    {
        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        public virtual Order Order { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        [DataType(DataType.Currency)]
        public virtual decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        public virtual int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        [DataType(DataType.Currency)]
        public virtual decimal? Discount { get; set; }
    }
}