using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ojb.Framework.ServiceBase.MessageModels;

namespace Ojb.DomainServices.Contract.MessageModels.Response
{
    using System.Runtime.Serialization;

    [DataContract]
    public class CategoryInfo : ResponseBase
    {
        [DataMember]
        public int Id;

        [DataMember]
        public string Name;

        public List<ProductInfo> Products;
    }
}
