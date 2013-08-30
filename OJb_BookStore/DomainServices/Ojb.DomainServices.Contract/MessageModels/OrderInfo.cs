namespace Ojb.DomainServices.Contract.MessageModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class OrderInfo
    {
        [DataMember]
        public int Id;

        [DataMember]
        public string CustomerName;

        [DataMember]
        public string CustomerPhoneNumber;

        [DataMember]
        public string CustomerAddress;
    }
}
