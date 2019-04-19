using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Initializers
{
    public class DataInitializer : CreateDatabaseIfNotExists<DataContext>
    {
        private List<City> cities;

        public DataInitializer()
        {
            cities = new List<City>
            {
                new City { Name = "Алматы" },
                new City { Name = "Нур-Султан" },
                new City { Name = "Шымкент" },
                new City { Name = "Караганда" },
                new City { Name = "Актобе" },
                new City { Name = "Тараз" },
                new City { Name = "Павлодар" },
                new City { Name = "Усть-Каменогорск" },
                new City { Name = "Семей" },
                new City { Name = "Костанай" },
                new City { Name = "Атырау" },
                new City { Name = "Кызылорда" },
                new City { Name = "Уральск" },
                new City { Name = "Петропавловск" },
                new City { Name = "Актау" },
                new City { Name = "Темиртау" },
                new City { Name = "Туркестан" },
                new City { Name = "Кокшетау" },
                new City { Name = "Талдыкорган" },
                new City { Name = "Экибастуз" },
                new City { Name = "Рудный" },
            };
        }

        protected override void Seed(DataContext context)
        {
            context.Cities.AddRange(cities);
            context.SaveChanges();
        }
    }
}