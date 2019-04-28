using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI
{
    public class Basket : Entity
    {
        public User User { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
