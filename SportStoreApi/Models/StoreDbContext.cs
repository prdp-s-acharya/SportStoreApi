using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SportStoreApi.Models
{
    public class StoreDbContext:DbContext 
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public StoreDbContext(DbContextOptions<StoreDbContext> o) : base(o) { }
    }
}
