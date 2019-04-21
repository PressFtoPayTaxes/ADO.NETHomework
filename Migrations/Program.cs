using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Нажмите любую клавишу, чтобы добавить запись, или напишите \"exit\", а затем нажмите клавишу ENTER, чтобы выйти");
                string answer = Console.ReadLine();
                if (answer == "exit")
                    Environment.Exit(0);

                Record record = new Record();
                Console.WriteLine("Для ввода печатайте значение, а затем используйте клавишу ENTER");

                Console.Write("Введите время входа в заведение (час): ");
                int hours = int.Parse(Console.ReadLine());
                Console.Write("Введите время входа в заведение (минута): ");
                int minutes = int.Parse(Console.ReadLine());
                Console.Write("Введите время входа в заведение (секунда): ");
                int seconds = int.Parse(Console.ReadLine());
                record.EntryTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hours, minutes, seconds);

                Console.Write("Введите время выхода из заведения (час): ");
                hours = int.Parse(Console.ReadLine());
                Console.Write("Введите время выхода из заведения (минута): ");
                minutes = int.Parse(Console.ReadLine());
                Console.Write("Введите время выхода из заведения (секунда): ");
                seconds = int.Parse(Console.ReadLine());
                record.LeavingTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hours, minutes, seconds);

                Console.Write("Введите имя посетителя: ");
                record.ClientName = Console.ReadLine();

                Console.Write("Введите номер его паспорта: ");
                record.PassportNumber = int.Parse(Console.ReadLine());

                Console.Write("Введите цель его посещения: ");
                record.VisitPurpose = Console.ReadLine();

                using (var context = new DataContext())
                {
                    context.Records.Add(record);
                    context.SaveChanges();
                }
            }

        }
    }
}
