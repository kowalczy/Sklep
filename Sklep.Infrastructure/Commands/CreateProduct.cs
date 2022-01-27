using System;
using System.Collections.Generic;
using System.Text;

namespace Sklep.Infrastructure.Commands
{
    public class CreateProduct
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
    }
}
