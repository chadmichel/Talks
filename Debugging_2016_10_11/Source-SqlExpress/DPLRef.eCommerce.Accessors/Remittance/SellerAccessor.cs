using System;
using System.Linq;

namespace DPLRef.eCommerce.Accessors.Remittance
{
    class SellerAccessor : AccessorBase, ISellerAccessor
    {
        public Seller Find(int id)
        {
            var db = new Models.eCommerceDbContext();
            var model = (from s in db.Sellers
                         where s.Id == id && s.IsDeleted == false
                         select s)
                        .FirstOrDefault();


            if (model != null)
            {
                var seller = new Seller();
                DTOMapper.Map(model, seller);
                return seller;
            }
            return null;
        }

        public Seller Save(Seller seller)
        {
            var db = new Models.eCommerceDbContext();
            Models.Seller model = null;
            if (seller.Id > 0)
            {
                model = db.Sellers.Find(seller.Id);
                DTOMapper.Map(seller, model);
            }
            else
            {
                model = new Models.Seller();
                DTOMapper.Map(seller, model);
                db.Sellers.Add(model);
            }
            db.SaveChanges();

            if (model != null && model.Id > 0)
            {
                var result = new Seller();
                DTOMapper.Map(model, result);         
                return result;
            }
            return null;
        }

        public void Delete(int id)
        {
            var db = new Models.eCommerceDbContext();
            var model = (from s in db.Sellers
                         where s.Id == id
                         select s)
                        .FirstOrDefault();


            if (model != null)
            {
                model.IsDeleted = true;
                //db.Sellers.Remove(model);
                db.SaveChanges();
            }
        }
    }
}
