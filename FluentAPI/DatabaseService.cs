using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI
{
    public class DatabaseService
    {
        public List<Product> GetProducts()
        {
            var products = new List<Product>();
            using (var context = new ShopContext())
            {
                products = context.Products.ToList();
            }
            return products;
        }

        public List<Basket> GetBaskets()
        {
            var baskets = new List<Basket>();
            using (var context = new ShopContext())
            {
                baskets = context.Baskets.ToList();
            }
            return baskets;
        }

        public bool LogIn(string login, string password, ref User userObject)
        {
            var users = new List<User>();

            using (var context = new ShopContext())
            {
                users = (from user
                        in context.Users
                         where user.Login == login
                         select user).ToList();
            }

            if (users.Count == 0)
                return false;

            if (password != users[0].Password)
                return false;

            userObject = users[0];
            return true;
        }
    }
}
