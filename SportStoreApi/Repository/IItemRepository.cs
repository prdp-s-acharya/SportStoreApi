using SportStoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStoreApi.Repository
{
    public interface IItemRepository
    {
        IList<Item> GetItem();
        Item GetItemById(int id);
        Item CreateItem(Item item);
        Item UpdateItem(int id, Item item);
        Item DeleteItem(int id);
        IList<Item> GetItemByCatagory(string cat);
    }
}
