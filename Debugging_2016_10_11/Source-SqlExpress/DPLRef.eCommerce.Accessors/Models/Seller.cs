using System;

namespace DPLRef.eCommerce.Accessors.Models
{
    class Seller
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string OrderNotificationEmail { get; set; }

        public int BankRoutingNumber { get; set; }

        public int BankAccountNumber { get; set; }

        public bool IsApproved { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string UserName { get; set; }
    }
}
