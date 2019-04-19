using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Initializers
{
    public class City : Entity
    {
        public string Name { get; set; }
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}
