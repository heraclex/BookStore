// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderMapping.cs" company="">
//   
// </copyright>
// <summary>
//   The order mapping.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using Ojb.DataModules.Product.Contract.Domain;
using Ojb.Framework.Mapping;

namespace Ojb.DataModules.Product.Mapping.Mappings
{
    /// <summary>
    /// The order mapping.
    /// </summary>
    public class OrderMapping : EntityMappingBase<Order>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderMapping"/> class.
        /// </summary>
        public OrderMapping()
        {
            this.ToTable("Order");
            this.Property(x => x.Id).HasColumnName("OrderId");
            this.Property(x => x.CustomerAddress);
            this.Property(x => x.CustomerName);
            this.Property(x => x.CustomerPhoneNumber);
            this.Property(x => x.EmployeeId);

            // http://stackoverflow.com/questions/7500747/entity-framework-one-to-many-relation-code-first
            this.HasMany(e => e.OrderDetailList).WithRequired(o => o.Order)
                                           .Map(p => p.MapKey("OrderId")).WillCascadeOnDelete();
        }
    }
}