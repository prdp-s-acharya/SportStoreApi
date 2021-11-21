using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportStoreApi.Models;

namespace SportStoreApi.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly StoreDbContext _context;

        public AuthRepository(StoreDbContext context)
        {
            _context = context;
        }
        public Customer Login(Customer customer)
        {
           return  _context.Customers.Where(u => u.Email == customer.Email).FirstOrDefault();
        }
    }
}
