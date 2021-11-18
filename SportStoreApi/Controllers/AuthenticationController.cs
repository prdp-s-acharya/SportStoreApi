using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportStoreApi.Models;

namespace SportStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly StoreDbContext _context;

        public AuthenticationController(StoreDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login([FromBody] Customer customer)
        {
            var user = _context.Customers.Where(u => u.Email == customer.Email).FirstOrDefault();
            if(user == null)
            {
                return Ok(user);
            }
            return Ok(user);
        }

    }
}