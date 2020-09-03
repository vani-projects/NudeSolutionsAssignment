using NudeSol.ContentLimitInsurance.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NudeSol.ContentLimitInsurance.WebAPI.Data
{
    public class ItemsDBRepository : IItemRepository
    {
        private ItemsDBContext _context;

        public ItemsDBRepository(ItemsDBContext context)
        {
            _context = context;
        }

        public void Delete(int itemId)
        {
            var itemToRemove = _context.Items.SingleOrDefault(i => i.Id == Convert.ToInt32(itemId));

            if (itemToRemove != null)
            {
                _context.Items.Remove(itemToRemove);
                _context.SaveChanges();

            }

        }

        public Item GetItemById(int itemId)
        {
            throw new NotImplementedException();
        }

        //display list of items 
        public IEnumerable<Item> GetItems()
        {
            var items = _context.Items.OrderBy(c => c.CategoryId).ToList();

            return items;

        }

        public IEnumerable<Item> GetItemsByCategory(int categoryId)
        {
            var items = _context.Items.
                   Where(cat => cat.CategoryId == categoryId).ToList();
            return items;

        }

        public void Insert(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();

        }

        public void Update(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
