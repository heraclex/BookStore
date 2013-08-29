// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Order.cs" company="">
//   
// </copyright>
// <summary>
//   The order.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Generic;
using Ojb.Framework.Domain.Entity;

namespace Ojb.DataModules.Product.Contract.Domain
{
    /// <summary>
    /// The order.
    /// </summary>
    public class Order : AuditEntity
    {
        /// <summary>
        /// Gets or sets the order date.
        /// </summary>
        public virtual DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets the employee id.
        /// </summary>
        public virtual int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the customer name.
        /// </summary>
        public virtual string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the customer address.
        /// </summary>
        public virtual string CustomerAddress { get; set; }

        /// <summary>
        /// Gets or sets the customer phone number.
        /// </summary>
        public virtual string CustomerPhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the order detail list.
        /// </summary>
        public virtual IList<OrderDetail> OrderDetailList { get; set; }
    }
}