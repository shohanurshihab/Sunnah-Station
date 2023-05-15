using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class DeliveryRepo : Repo, IRepo<Delivery, int, Delivery>
    {
        public Delivery Create(Delivery obj)
    {
        db.Deliveries.Add(obj);
        if (db.SaveChanges() > 0) return obj;
        return null;
    }
    public bool Delete(int id)
    {
        var ex = Read(id);
        db.Deliveries.Remove(ex);
        return db.SaveChanges() > 0;
    }

    public List<Delivery> Read()
    {
        return db.Deliveries.ToList();
    }


    public Delivery Read(int id)
    {
        return db.Deliveries.Find(id);
    }

    public Delivery Update(Delivery obj)
    {
        var ex = Read(obj.Id);
        db.Entry(ex).CurrentValues.SetValues(obj);
        if (db.SaveChanges() > 0) return obj;
        return null;
    }
}
}

