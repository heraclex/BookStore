using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ojb.DomainServices.Contract.MessageModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class CategoryInfo
    {
        [DataMember]
        public int Id;

        [DataMember]
        public string Name;

        public List<ProductInfo> Products;
    }
}
