using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в магазин!");

            var currentUser = LogIn();

            while (true)
            {
                Console.WriteLine("Выберите действие:\n1 - выбрать продукты\n2 - удалить продукты из корзины\n3 - купить продукты\n4 - выход");
                int answer = int.Parse(Console.ReadLine());

                switch (answer)
                {
                    case 1: ChooseProducts(currentUser); break;
                    case 2: DeleteProducts(currentUser); break;
                    case 3: var handler = new DatabaseService();
                        (from basket
                         in handler.GetBaskets()
                         where basket.User.Id == currentUser.Id
                         select basket).ToList()[0].Products.Clear();
                        Console.WriteLine("Продукты куплены");
                        break;
                    case 4: Environment.Exit(0); break;
                    default: Console.WriteLine("Такого варианта нет"); break;
                }
            }
        }

        private static void ChooseProducts(User user)
        {
            var products = new List<Product>();
            var handler = new DatabaseService();
            products = handler.GetProducts();

            for (int i = 0; i < products.Count; i++)
                Console.WriteLine($"{i + 1}: {products[i].Name}");

            int index = -1;
            while (index <= 0 || index > products.Count)
            {
                Console.Write("Выберите номер продукта: ");
                index = int.Parse(Console.ReadLine());
            }

            var selectedProduct = products[index - 1];

            var baskets = (from basket
                          in handler.GetBaskets()
                           where basket.User.Id == user.Id
                           select basket).ToList();

            baskets[0].Products.Add(selectedProduct);
        }

        private static User LogIn()
        {
            while (true)
            {
                Console.WriteLine("Войдите в систему");
                var user = new User();

                while (user.Login == null || user.Login == string.Empty)
                {
                    Console.Write("Введите логин: ");
                    user.Login = Console.ReadLine();
                }
                while (user.Password == null || user.Password == string.Empty)
                {
                    Console.Write("Введите логин: ");
                    user.Password = Console.ReadLine();
                }

                var handler = new DatabaseService();

                if (!handler.LogIn(user.Login, user.Password, ref user))
                    Console.WriteLine("Пользователя с такими логином и паролем не существует");
                else
                    return user;
            }
        }

        private static void DeleteProducts(User user)
        {
            var handler = new DatabaseService();

            var baskets = (from basket
                           in handler.GetBaskets()
                           where basket.User.Id == user.Id
                           select basket).ToList();

            for (int i = 0; i < baskets[0].Products.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {baskets[0].Products.ToList()[i].Name}");
            }

            int index = -1;
            while(index <= 0 || index > baskets[0].Products.Count)
            {
                Console.Write("Выберите номер продукта: ");
                index = int.Parse(Console.ReadLine());
            }

            baskets[0].Products.Remove(baskets[0].Products.ToList()[index - 1]);
        }
    }
}