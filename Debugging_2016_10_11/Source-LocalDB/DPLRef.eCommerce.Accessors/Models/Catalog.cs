using System;

namespace DPLRef.eCommerce.Accessors.Models
{
    class Catalog
    {
        public int Id { get; set; }

        public int SellerId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsAvailable { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime  UpdatedAt { get; set; }
    }
}
