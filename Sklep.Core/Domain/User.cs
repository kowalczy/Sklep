using System;
using System.Collections.Generic;
using System.Text;

namespace Sklep.Core.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Surname { get; set; }
        public UserDetails UserDetails { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
