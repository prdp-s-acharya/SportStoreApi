using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportStoreApi.Models;
using SportStoreApi.Repository;

namespace SportStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderRepository repo;
        public OrdersController(IOrderRepository repository)
        {
            repo = repository;
        }

        // GET: api/Orders
        //[HttpGet]
        //public IEnumerable<Order> GetOrders()
        //{
        //    return _context.Orders;
        //}

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public IActionResult GetOrder([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orders = repo.GetOrder(id);              

            if (orders == null)
            {
                return NotFound();
            }

            return Ok(orders);
        }

        // PUT: api/Orders/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutOrder([FromRoute] int id, [FromBody] Order order)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != order.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(order).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OrderExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Orders
        [HttpPost]
        public IActionResult PostOrder([FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var neworder = repo.CreateOrder(order);
            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var order = await _context.Orders.FindAsync(id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Orders.Remove(order);
        //    await _context.SaveChangesAsync();

        //    return Ok(order);
        //}

      
    }
}