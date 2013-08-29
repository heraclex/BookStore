// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderDetailMapping.cs" company="">
//   
// </copyright>
// <summary>
//   The order detail mapping.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using Ojb.DataModules.Product.Contract.Domain;
using Ojb.Framework.Mapping;

namespace Ojb.DataModules.Product.Mapping.Mappings
{
    /// <summary>
    /// The order detail mapping.
    /// </summary>
    public class OrderDetailMapping : EntityMappingBase<OrderDetail>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderDetailMapping"/> class.
        /// </summary>
        public OrderDetailMapping()
        {
            this.ToTable("OrderDetail");
            this.Property(x => x.Id).HasColumnName("OrderDetailId");
            this.Property(x => x.Discount);
            this.Property(x => x.Quantity);
            this.Property(x => x.UnitPrice);

            // http://stackoverflow.com/questions/7500747/entity-framework-one-to-many-relation-code-first
            this.HasRequired(e => e.Product).WithOptional()
                                       .Map(p => p.MapKey("ProductId")).WillCascadeOnDelete(false);
        }
    }
}