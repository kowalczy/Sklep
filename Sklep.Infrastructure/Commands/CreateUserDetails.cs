using System;
using System.Collections.Generic;
using System.Text;

namespace Sklep.Infrastructure.Commands
{
    public class CreateUserDetails
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public int UserId { get; set; }
    }
}
