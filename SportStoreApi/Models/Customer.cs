﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStoreApi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long ContactNumber { get; set; }
        public string Address { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}