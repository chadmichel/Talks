using System.Runtime.Serialization;

namespace DPLRef.eCommerce.Accessors.Catalog
{
    [DataContract]
    public class WebStoreCatalog
    {
        [DataMember]
        public int Id { get; set; }


        [DataMember]
        public int SellerId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string SellerName { get; set; }

        [DataMember]
        public bool IsApproved { get; internal set; }
    }

}
