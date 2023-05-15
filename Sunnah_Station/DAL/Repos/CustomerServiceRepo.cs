using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CustomerServiceRepo : Repo, IRepo<CustomerService, int, CustomerService>
    {
        public CustomerService Create(CustomerService obj)
        {
            db.CustomerServices.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
        public bool Delete(int id)
        {
            var ex = Read(id);
            db.CustomerServices.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<CustomerService> Read()
        {
            return db.CustomerServices.ToList();
        }


        public CustomerService Read(int id)
        {
            return db.CustomerServices.Find(id);
        }

        public CustomerService Update(CustomerService obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}

