using NudeSol.ContentLimitInsurance.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NudeSol.ContentLimitInsurance.WebAPI.Data
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetItems();

        IEnumerable<Item> GetItemsByCategory(int categoryId);

        Item GetItemById(int itemId);

        void Insert(Item item);

        void Update(Item item);

        void Delete(int itemId);

    }
}
