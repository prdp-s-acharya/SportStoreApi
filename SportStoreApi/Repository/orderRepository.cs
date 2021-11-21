using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportStoreApi.Models;

namespace SportStoreApi.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private StoreDbContext _context;
        public OrderRepository(StoreDbContext context)
        {
            _context = context;
        }
        public Order CreateOrder(Order order)
        {
            int maxOrderNo = 0;
            try
            {
                maxOrderNo = (from o in _context.Orders
                              where o.CustomerId == order.Customer.Id
                              select o.OrderNo).Max();
            }
            catch { maxOrderNo = 0; }

            foreach (var o in order.Item)
            {
                Order newOrder = new Order
                {
                    CustomerId = order.Customer.Id,
                    ItemID = o.Id,
                    OrderNo = maxOrderNo + 1,
                    OrderDate = order.OrderDate,
                    PaymentMode = order.PaymentMode
                };
                _context.Orders.Add(newOrder);
                _context.SaveChanges();
            }
            return order;
        }

        public IList<Order> GetOrder(int id)
        {
            var orderlist = (from o in _context.Orders
                             where o.CustomerId == id
                             select o.OrderNo).ToHashSet();
            List<Order> orders = new List<Order>();

            foreach (var orderNumber in orderlist)
            {
                var specificOrder = _context.Orders.Where<Order>(o => o.OrderNo == orderNumber).Where(c => c.CustomerId == id);

                var items = (from o in specificOrder
                             join i in _context.Items
                             on o.ItemID equals i.Id
                             select i).ToList();
                Order order = new Order();
                order.Item = items;
                order.OrderNo = orderNumber;
                var orderquary = _context.Orders.Where(o => o.OrderNo == orderNumber).FirstOrDefault();
                order.Id = orderquary.Id;
                order.OrderDate = orderquary.OrderDate;
                order.PaymentMode = orderquary.PaymentMode;
                orders.Add(order);
            }
            return orders;
        }
    }
}
