using System;
using System.Collections.Generic;
using System.Text;

namespace Sklep.Core.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public Transaction Transaction { get; set; }



    }
}
