using SportStoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStoreApi.Repository
{
    public interface IOrderRepository
    {
        IList<Order> GetOrder(int id);
        Order CreateOrder(Order order);
    }
}
