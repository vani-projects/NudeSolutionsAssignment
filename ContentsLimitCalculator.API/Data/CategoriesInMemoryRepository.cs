using NudeSol.ContentLimitInsurance.WebAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NudeSol.ContentLimitInsurance.WebAPI.Data
{
    public class CategoriesInMemoryRepository : ICategoryRepository
    {
        private static List<Category> _categories;
        private IItemRepository _itemRepository;

        public CategoriesInMemoryRepository(IItemRepository itemRepository)
        {
            this._itemRepository = itemRepository;
            //Hardcoded Intitialization of static categories
            _categories = new List<Category>
            {
                new Category{Id=1,Name="Electronics"},
                new Category{Id=2,Name="Clothing"},
                new Category{Id=3,Name="Kitchen"},
            };
        }
        public void Delete(Category category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            foreach (Category cat in _categories)
            {
                cat.Items = _itemRepository.GetItemsByCategory(cat.Id).ToList();
            }
            return _categories.OrderBy(c => c.Name).ToList();

        }

        public IList GetAsKeyValuePairs()
        {
            var types = _categories.Select(c => new
            {
                Value = c.Id,
                Text = c.Name
            }).ToList();
            return types;
        }

        public Category GetCategoryById(int categoryId)
        {
            return _categories.Find(cat => cat.Id == categoryId);
        }

        public void Insert(Category category)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
