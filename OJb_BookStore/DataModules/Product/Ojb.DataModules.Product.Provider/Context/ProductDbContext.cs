// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductDbContext.cs" company="">
//   
// </copyright>
// <summary>
//   The product db context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Data.Entity;
using Ojb.DataModules.Product.Contract.Domain;
using Ojb.DataModules.Product.Mapping.Mappings;
using Ojb.Framework.EntityFrameworkProvider.DbContext;

namespace Ojb.DataModules.Product.Provider.Context
{
    /// <summary>
    /// The product db context.
    /// </summary>
    public class ProductDbContext : OjbDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductDbContext"/> class.
        /// </summary>
        public ProductDbContext()
            : this("DefaultDb")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductDbContext"/> class.
        /// </summary>
        /// <param name="connStringName">
        /// The conn string name.
        /// </param>
        public ProductDbContext(string connStringName)
            : base(connStringName)
        {
        }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        public DbSet<Contract.Domain.Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        public DbSet<Order> Order { get; set; }

        /// <summary>
        /// Gets or sets the order detail.
        /// </summary>
        public DbSet<OrderDetail> OrderDetail { get; set; }

        /// <summary>
        /// The on model creating.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // will be refactored to Module and registerd automatically
            modelBuilder.Configurations.Add(new CategoryMapping());
            modelBuilder.Configurations.Add(new OrderMapping());
            modelBuilder.Configurations.Add(new OrderDetailMapping());
            modelBuilder.Configurations.Add(new ProductMapping());
        }
    }
}