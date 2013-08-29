

namespace Ojb.DataModules.Product.Contract.Domain
{
    using Ojb.Framework.Domain.Entity;

    public class OrderDetail : AuditEntity
    {
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual double UnitPrice { get; set; }
        public virtual int Quantity { get; set; }
        public virtual float Discount { get; set; }
    }
}
