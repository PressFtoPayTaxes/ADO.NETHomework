using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFIntroduction
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ManufacturerName { get; set; }
        public int Cost { get; set; }

        public Product()
        {
            Id = Guid.NewGuid();
        }
    }
}
