
namespace Ojb.DataModules.Product.Contract.Domain
{
    using System;
    using Ojb.Framework.Domain.Entity;

    public class Order : AuditEntity
    {
        public virtual DateTime OrderDate { get; set; }
        public virtual int EmployeeId { get; set; }
        public virtual string CustomerName { get; set; }
        public virtual string CustomerAddress { get; set; }
        public virtual string CustomerPhoneNumber { get; set; }
    }
}
