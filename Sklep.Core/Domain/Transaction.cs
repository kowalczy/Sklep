using System;
using System.Collections.Generic;
using System.Text;

namespace Sklep.Core.Domain
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public List<Product> Products { get; set; }
        public User User { get; set; }

    }   
}
