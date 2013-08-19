namespace Ojb.Framework.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using Ojb.Framework.Domain.Entity;

    public abstract class EntityMappingBase<T> : EntityTypeConfiguration<T> where T : AuditEntity
    {
        protected EntityMappingBase()
        {
            HasKey(x => x.Id);

            #region Audit section

            Property(x => x.CreatedBy).HasColumnName("CreatedBy");
            Property(x => x.CreatedDate).HasColumnName("CreatedDate");
            Property(x => x.ModifiedBy).HasColumnName("ModifiedBy");
            Property(x => x.ModifiedDate).HasColumnName("ModifiedDate");
            Property(x => x.IsDeleted).HasColumnName("IsDeleted");
            
            #endregion
        }
    }
}
