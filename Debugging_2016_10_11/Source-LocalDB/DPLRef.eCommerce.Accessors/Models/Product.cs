using System;

namespace DPLRef.eCommerce.Accessors.Models
{
    class Product
    {
        public int Id { get; set; }

        public int CatalogId { get; set; }

        public string SellerProductId { get; set; }

        public string Name { get; set; }

        public string Summary { get; set; }

        public string  Detail { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool IsAvailable { get; set; }

        public string SupplierName { get; set; }

        public decimal ShippingWeight { get; set; }

        public bool IsDownloadable { get; set; }
    }
}
