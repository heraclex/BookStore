namespace Ojb.Framework.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using Ojb.Framework.Domain.Entity;

    public abstract class EntityMappingBase<T> : EntityTypeConfiguration<T> where T : AuditEntity
    {
        protected EntityMappingBase()
        {
            this.HasKey(x => x.Id);

            #region Audit section

            this.Property(x => x.CreatedBy).HasColumnName("CreatedBy");
            this.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
            this.Property(x => x.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(x => x.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(x => x.IsDeleted).HasColumnName("IsDeleted");
            
            #endregion
        }
    }
}
