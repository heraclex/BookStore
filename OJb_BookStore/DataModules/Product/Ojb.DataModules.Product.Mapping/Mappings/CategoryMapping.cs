// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CategoryMapping.cs" company="">
//   
// </copyright>
// <summary>
//   The category mapping.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using Ojb.DataModules.Product.Contract.Domain;
using Ojb.Framework.Mapping;

namespace Ojb.DataModules.Product.Mapping.Mappings
{
    /// <summary>
    /// The category mapping.
    /// </summary>
    public class CategoryMapping : EntityMappingBase<Category>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CategoryMapping" /> class.
        /// </summary>
        public CategoryMapping()
        {
            this.ToTable("Category");
            this.Property(x => x.Id).HasColumnName("CategoryId");
            this.Property(x => x.Name);
            this.HasMany(x => x.Products).WithRequired(o => o.Category)
                .Map(p => p.MapKey("CategoryId")).WillCascadeOnDelete();
        }
    }
}