using SportStoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStoreApi.Repository
{
    interface IAuthRepository
    {
        Customer Login(Customer customer);
    }
}
