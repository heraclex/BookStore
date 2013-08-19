namespace Ojb.DomainServices.Contract.MessageModels
{
    using System.Runtime.Serialization;

    [DataContract]
    public class AccountInfo
    {
        [DataMember]
        public int Id;

        [DataMember]
        public string UserName;

        [DataMember]
        public string Password;

        [DataMember]
        public string FisrtName;

        [DataMember]
        public string LastName;

        [DataMember]
        public string PhoneNumber;
    }
}
