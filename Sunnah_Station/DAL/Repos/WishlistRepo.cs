using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class WishlistRepo : Repo, IRepo<Wishlist, int, Wishlist>
    {
        public Wishlist Create(Wishlist obj)
        {
            db.Wishlists.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Wishlists.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Wishlist> Read()
        {
            return db.Wishlists.ToList();
        }


        public Wishlist Read(int id)
        {
            return db.Wishlists.Find(id);
        }

        public Wishlist Update(Wishlist obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
