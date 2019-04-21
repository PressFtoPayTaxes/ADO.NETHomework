using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFIntroduction
{
    class Program
    {
        static Product CreateProduct()
        {
            Product product = new Product();
            while (true)
            {
                Console.Write("Введите название товара: ");
                product.Name = Console.ReadLine();
                if (product.Name == string.Empty)
                {
                    Console.WriteLine("Вы ничего не ввели");
                    continue;
                }
                break;
            }

            while (true)
            {
                Console.Write("Введите название производителя: ");
                product.ManufacturerName = Console.ReadLine();
                if (product.ManufacturerName == string.Empty)
                {
                    Console.WriteLine("Вы ничего не ввели");
                    continue;
                }
                break;
            }

            while (true)
            {
                Console.Write("Введите цену товара: ");
                product.Cost = int.Parse(Console.ReadLine());
                if (product.Cost <= 0)
                {
                    Console.WriteLine("Цена должна быть больше нуля");
                    continue;
                }
                break;
            }

            return product;
        }

        static void AddProduct()
        {
            Product product = CreateProduct();

            using (var context = new StorageContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        static void DeleteProduct()
        {
            Console.Write("Введите название продукта: ");
            string productName = Console.ReadLine();

            Console.Write("Введите название производителя: ");
            string manufacturerName = Console.ReadLine();

            Product deletingProduct = new Product();
            using (var context = new StorageContext())
            {
                foreach(var product in context.Products)
                {
                    if (product.Name == productName && product.ManufacturerName == manufacturerName)
                        deletingProduct = product;
                }
                context.Products.Remove(deletingProduct);
                context.SaveChanges();
            }
        }

        static void RedactProduct()
        {
            DeleteProduct();
            AddProduct();
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1 - Просмотреть товары\n2 - Добавить товар\n3 - Изменить товар\n4 - Удалить товар\n5 - Выход");
                int answer = int.Parse(Console.ReadLine());

                switch (answer)
                {
                    case 1:
                        using (var context = new StorageContext())
                            foreach (var product in context.Products)
                                Console.WriteLine($"{product.Name} от {product.ManufacturerName}: {product.Cost} тг");
                        break;
                    case 2:
                        AddProduct();
                        break;
                    case 3: RedactProduct(); break;
                    case 4: DeleteProduct(); break;
                    case 5: Environment.Exit(0); break;
                    default:
                        Console.WriteLine("Такого варианта нет");
                        break;
                }
            }
        }
    }
}
