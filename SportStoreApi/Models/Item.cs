using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStoreApi.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public int Size { get; set; }
        public string Catagory { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Order Orders { get; set; }
    }
}
