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
    public class ItemsController : ControllerBase
    {
        private IItemRepository _repo;
        public ItemsController(IItemRepository itemRepository)
        {
            _repo = itemRepository;
        }

        // GET: api/Items
        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            return _repo.GetItem();
        }

        // GET: api/Items/5
        [HttpGet("{id}/item")]
        public IActionResult GetItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = _repo.GetItemById(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }
        [HttpGet("{cat}")]
        public IActionResult GetItemByCatagory([FromRoute] string cat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = _repo.GetItemByCatagory(cat);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // PUT: api/Items/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem([FromRoute] int id, [FromBody] Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.Id)
            {
                return BadRequest();
            }

            var updatedItem = _repo.UpdateItem(id, item);

            return NoContent();
        }

        // POST: api/Items
        [HttpPost]
        public IActionResult PostItem([FromBody] Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.CreateItem(item);

            return CreatedAtAction("GetItem", new { id = item.Id }, item);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = _repo.DeleteItem(id);
            return Ok(item);
        }

    }
}