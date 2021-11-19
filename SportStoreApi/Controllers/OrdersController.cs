using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportStoreApi.Models;

namespace SportStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly StoreDbContext _context;

        public OrdersController(StoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders;
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public IActionResult GetOrder([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderlist = (from o in _context.Orders
                              where o.CustomerId == id
                              select o.OrderNo).ToHashSet();
            List<Order> orders = new List<Order>();

            foreach(var orderNumber in orderlist)
            {
                var specificOrder = _context.Orders.Where<Order>(o=>o.OrderNo == orderNumber);

                var items = (from o in specificOrder
                             join i in _context.Items
                             on o.ItemID equals i.Id
                             select i).ToList();
                Order order = new Order();
                order.Item = items;
                order.OrderNo = orderNumber;
                var orderquary = _context.Orders.Where(o=>o.OrderNo == orderNumber).FirstOrDefault();
                order.Id = orderquary.Id;
                order.OrderDate = orderquary.OrderDate;
                order.PaymentMode = orderquary.PaymentMode;
                orders.Add(order);
            }                 

            if (orders == null)
            {
                return NotFound();
            }

            return Ok(orders);
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder([FromRoute] int id, [FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.Id)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orders
        [HttpPost]
        public IActionResult PostOrder([FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
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
            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return Ok(order);
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}