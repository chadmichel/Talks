using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DPLRef.eCommerce.Common.Shared
{
    [DataContract]
    public class AmbientContext
    {
        [DataMember]
        public int SellerId { get; set; }

        [DataMember]
        public string SellerAuthToken { get; set; }

        [DataMember]
        public int BuyerId { get; set; }

        [DataMember]
        public int CatalogId { get; set; }
    }
}
