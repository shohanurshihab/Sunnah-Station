using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, int, User>
    {
        public User Create(User obj)
        {
            db.Users.Add(obj);

            if (db.SaveChanges() > 0) return obj;

            return null;
        }

        public List<User> Read()
        {
            return db.Users.ToList();
        }

        public User Read(int id)
        {
            return db.Users.Find(id);
        }

        public User GetByEmail(string email)
        {
            var userExists = (from user in db.Users where user.Email.Equals(email) select user).SingleOrDefault();

            return userExists;
        }

        public User Update(User obj)
        {
            var ex = Read(obj.Id);

            db.Entry(ex).CurrentValues.SetValues(obj);

            if (db.SaveChanges() > 0) return obj;

            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);

            db.Users.Remove(ex);

            return db.SaveChanges() > 0;
        }
    }
}
