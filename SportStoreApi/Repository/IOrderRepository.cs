using SportStoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStoreApi.Repository
{
    interface IOrderRepository
    {
        Order GetOrder(int id);
        Order CreateOrder(Order order);
    }
}
