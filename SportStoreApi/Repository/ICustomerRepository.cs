using SportStoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStoreApi.Repository
{
    public interface ICustomerRepository
    {
        Customer CreateCustomer(Customer customer);
        IList<Customer> GetCustomers();
        Customer EditCustomer(int id, Customer customer);
        Customer DeleteCustomer(int id);
    }
}
