using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportStoreApi.Models;
using SportStoreApi.Repository;

namespace SportStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthRepository _repo;
        public AuthenticationController(IAuthRepository authRepository)
        {
            _repo = authRepository;
        }

        [HttpPost]
        public IActionResult Login([FromBody] Customer customer)
        {
            var user = _repo.Login(customer);
            if(user == null)
            {
                return Ok(user);
            }
            return Ok(user);
        }

    }
}