using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPLRef.eCommerce.Accessors.Models
{
    /// <summary>
    /// DESIGN NOTE: Everytime you add another database model, add it to
    /// DTOMapper too.
    /// </summary>
    class eCommerceDbContext : DbContext
    {
        public eCommerceDbContext() 
            : base("eCommerceDatabase")
        {
            Database.SetInitializer<eCommerceDbContext>(null);
        }

        public DbSet<Catalog> Catalogs { get; set; }

        public DbSet<Seller> Sellers { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
