using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DPLRef.eCommerce.Accessors.Remittance
{
    [DataContract]
    public class Seller
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string OrderNotificationEmail { get; set; }

        [DataMember]
        public int BankRoutingNumber { get; set; }

        [DataMember]
        public int BankAccountNumber { get; set; }

        [DataMember]
        public bool IsApproved { get; set; }

        [DataMember]
        public string UserName { get; set; }
    }
}
