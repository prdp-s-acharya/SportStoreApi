using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportStoreApi.Models;

namespace SportStoreApi.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly StoreDbContext _context;

        public ItemRepository(StoreDbContext context)
        {
            _context = context;
        }
        public Item CreateItem(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Item DeleteItem(int id)
        {
            Item item = _context.Items.Find(id);
            _context.Items.Remove(item);
            _context.SaveChanges();
            return item;
        }

        public IList<Item> GetItem()
        {
            return _context.Items.ToList<Item>();
        }

        public IList<Item> GetItemByCatagory(string cat)
        {
            return  _context.Items.Where(i => i.Catagory.Equals(cat)).ToList<Item>();
        }

        public Item GetItemById(int id)
        {
            return _context.Items.Find(id);
        }

        public Item UpdateItem(int id, Item item)
        {
            _context.Items.Update(item);
            _context.SaveChanges();
            return item;
        }
    }
}
