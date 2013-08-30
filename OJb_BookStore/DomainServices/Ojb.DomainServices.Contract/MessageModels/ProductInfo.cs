
namespace Ojb.DomainServices.Contract.MessageModels
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class ProductInfo
    {
        [DataMember]
        public int Id;

        [DataMember]
        public string Description;

        [DataMember]
        public string ImagePath;

        [DataMember]
        public double UnitPrice;

        [DataMember]
        public CategoryInfo Category;
    }
}
