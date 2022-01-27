﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sklep.Core.Domain
{
    public class UserDetails
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
