using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Product,int,Product> ProductData()
        {
            return new ProductRepo();
        }
        public static IRepo<Order,int,Order> OrderData()
        {
            return new OrderRepo();
        }
        public static IRepo<Category,int,Category> CategoryData()
        {
            return new CategoryRepo();
        }

        public static IUser<User, int, User> UserData()
        {
            return new UserRepo();
        }
        public static IRepo<CustomerService, int, CustomerService> CustomerServiceData()
        {
            return new CustomerServiceRepo();
        }

        public static IRepo<OrderItem, int, OrderItem> OrderItemData()
        {
            return new OrderItemRepo();
        }
        public static IRepo<Wishlist, int, Wishlist> WishlistData()
        {
            return new WishlistRepo();
        }

        public static IRepo<Delivery, int, Delivery> DeliveryData()
        {
            return new DeliveryRepo();
        }

        public static IAuth<bool> AuthData()
        {
            return new UserRepo();
        }
        public static IRepo<Token,string,Token> TokenData()
        {
            return new TokenRepo();
        }
    }
}
