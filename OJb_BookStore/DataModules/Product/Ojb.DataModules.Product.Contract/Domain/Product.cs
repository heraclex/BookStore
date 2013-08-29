
namespace Ojb.DataModules.Product.Contract.Domain
{
    using Ojb.Framework.Domain.Entity;

    public class Product : AuditEntity
    {
        public virtual Category Category { get; set; }
        public virtual string Description { get; set; }
        public virtual string ImagePath { get; set; }
        public virtual double UnitPrice { get; set; }
    }
}
