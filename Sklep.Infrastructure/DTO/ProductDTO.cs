using System;
using System.Collections.Generic;
using System.Text;

namespace Sklep.Infrastructure.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
    }
}
