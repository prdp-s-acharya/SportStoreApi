using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportStoreApi.Models;

namespace SportStoreApi.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly StoreDbContext _context;

        public CustomerRepository(StoreDbContext context)
        {
            _context = context;
        }
        public Customer CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public Customer DeleteCustomer(int id)
        {
            var customer = _context.Customers.Find(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return customer;
        }

        public Customer EditCustomer(int id, Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return customer;
        }

        public IList<Customer> GetCustomers()
        {
            return _context.Customers.ToList<Customer>();
        }
    }
}
