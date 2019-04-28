using System;
using System.Collections;
using System.Collections.Generic;

namespace FluentAPI
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public ICollection<Basket> Baskets { get; set; }
    }
}