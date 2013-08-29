// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductMapping.cs" company="">
//   
// </copyright>
// <summary>
//   The product mapping.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using Ojb.Framework.Mapping;

namespace Ojb.DataModules.Product.Mapping.Mappings
{
    /// <summary>
    /// The product mapping.
    /// </summary>
    public class ProductMapping : EntityMappingBase<Contract.Domain.Product>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductMapping"/> class.
        /// </summary>
        public ProductMapping()
        {
            this.ToTable("Product");
            this.Property(x => x.Description);
            this.Property(x => x.ImagePath);
            this.Property(x => x.UnitPrice);
        }
    }
}