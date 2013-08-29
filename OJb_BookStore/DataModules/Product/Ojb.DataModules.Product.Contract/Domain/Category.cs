

namespace Ojb.DataModules.Product.Contract.Domain
{
    using System.Collections.Generic;

    using Ojb.Framework.Domain.Entity;

    public class Category : AuditEntity
    {
        public Category()
        {
            this.Products = new List<Product>();
        }

        public virtual string Name { get; set; }

        public virtual IList<Product> Products { get; set; }
    }
}
