using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStoreApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderNo { get; set; }
        public int ItemID { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public string PaymentMode { get; set; }

        public Item Item { get; set; }
        public Customer Customer { get; set; }
    }
}
