using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLevelPart2
{
    class Program
    {
        static void ShowUsers()
        {
            bool isAdminFiltrationEnabled;
            while (true)
            {
                Console.WriteLine("Включить фильтрацию по админам?(1 - да, 2 - нет)");
                int answer = int.Parse(Console.ReadLine());
                switch(answer)
                {
                    case 1: isAdminFiltrationEnabled = true; break;
                    case 2: isAdminFiltrationEnabled = false; break;
                    default: Console.WriteLine("Такого варианта нет"); continue;
                }
                break;
            }

            UsersHandler handler = new UsersHandler();
            var usersSet = handler.GetUsers();

            Console.WriteLine("Логин:\t\tПароль:\t\tАдрес:\t\tТелефонный номер:\t\t\tАдмин:");
            foreach(DataRow row in usersSet.Tables["Users"].Rows)
            {
                User user = new User
                {
                    Login = row.ItemArray[1].ToString(),
                    Password = row.ItemArray[2].ToString(),
                    Address = row.ItemArray[3].ToString(),
                    PhoneNumber = row.ItemArray[4].ToString(),
                    IsAdmin = bool.Parse(row.ItemArray[5].ToString())
                };
                if (!isAdminFiltrationEnabled)
                    Console.WriteLine($"{user.Login}\t\t{user.Password}\t\t{user.Address}\t\t{user.PhoneNumber}\t\t\t{user.IsAdmin}");
                else if (user.IsAdmin)
                    Console.WriteLine($"{user.Login}\t\t{user.Password}\t\t{user.Address}\t\t{user.PhoneNumber}\t\t\t{user.IsAdmin}");
            }
        }

        static void AddUser()
        {
            UsersHandler handler = new UsersHandler();

            Console.Write("Введите логин: ");
            string login = Console.ReadLine();

            var users = handler.GetUsers();
            foreach(DataRow row in users.Tables["Users"].Rows)
            {
                if (row.ItemArray[1].ToString() == login)
                {
                    Console.WriteLine("Пользователь с таким логином уже существует");
                    return;
                }
            }

            Console.Write("Введите пароль: ");
            string password = Console.ReadLine();
            Console.Write("Введите адрес: ");
            string address = Console.ReadLine();
            Console.Write("Введите номер телефона: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Является ли он админом? (true, false): ");
            bool isAdmin = bool.Parse(Console.ReadLine());

            handler.AddUser(login, password, address, phoneNumber, isAdmin);
        }

        static void RedactUser()
        {
            var handler = new UsersHandler();
            Console.Write("Введите логин редактируемого пользователя: ");
            string login = Console.ReadLine();

            User user = new User();

            var users = handler.GetUsers();
            foreach(DataRow row in users.Tables["Users"].Rows)
            {
                if (row.ItemArray[1].ToString() == login)
                {
                    user = new User
                    {
                        Login = row.ItemArray[1].ToString(),
                        Password = row.ItemArray[2].ToString(),
                        Address = row.ItemArray[3].ToString(),
                        PhoneNumber = row.ItemArray[4].ToString(),
                        IsAdmin = bool.Parse(row.ItemArray[5].ToString())
                    };
                    break;
                }
            }

            if (user.Login == null)
            {
                Console.WriteLine("Такого пользователя нет");
                return;
            }

            Console.Write($"Введите новый пароль (старый - {user.Password}): ");
            string password = Console.ReadLine();
            Console.Write($"Введите новый адрес (старый - {user.Address}): ");
            string address = Console.ReadLine();
            Console.Write($"Введите новый номер телефона (старый - {user.PhoneNumber}): ");
            string phoneNumber = Console.ReadLine();
            Console.Write($"Является ли он админом? (сейчас - {user.IsAdmin}): ");
            bool isAdmin = bool.Parse(Console.ReadLine());

            handler.RedactUser(login, password, address, phoneNumber, isAdmin);
        }

        static void DeleteUser()
        {
            Console.Write("Введите логин удаляемого пользователя: ");
            string login = Console.ReadLine();

            var handler = new UsersHandler();
            handler.DeleteUser(login);
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1 - Показать список пользователей\n2 - Добавить пользователя\n3 - Редактировать пользователя\n4 - Удалить пользователя\n5 - Выход");
                int answer = int.Parse(Console.ReadLine());
                
                switch (answer)
                {
                    case 1: ShowUsers(); break;
                    case 2: AddUser(); break;
                    case 3: RedactUser(); break;
                    case 4: DeleteUser(); break;
                    case 5: Environment.Exit(0); break;
                    default: Console.WriteLine("Такого ответа нет"); break;
                }
            }

        }
    }
}
