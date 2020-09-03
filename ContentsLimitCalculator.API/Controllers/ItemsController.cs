using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NudeSol.ContentLimitInsurance.WebAPI.Data;
using NudeSol.ContentLimitInsurance.WebAPI.Models;

namespace NudeSol.ContentLimitInsurance.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {

        private IItemRepository _itemRepository;
        private ICategoryRepository _categoryRepository;

        public ItemsController(IItemRepository itemsDBRepository, ICategoryRepository categoryRepository)
        {
            _itemRepository = itemsDBRepository;
            _categoryRepository = categoryRepository;
        }

        /*
        //GET : /api/items
        [HttpGet("/api/items")] //path parameters
        public IEnumerable<Item> Get()
        {
            return _itemRepository.GetItems();
        }

        [HttpGet("/api/itemsByCategory")] //path parameters
        public IEnumerable<Category> GetItemsGroupedByCategories()
        {
            List<Category> result = new List<Category>();
            List<Item> items = _itemRepository.GetItems().ToList();
            items.ForEach(item => {
                Category category = result.Find(category => category.Id == item.CategoryId);
                if(category == null)
                {
                    category = _categoryRepository.GetCategoryById(item.CategoryId);
                    category.Items = new List<Item>();
                }
                category.Items.Add(item);
                result.Add(category);
            });

            return result;
        }*/

        [HttpPost]
        public ActionResult AddItem(Item item)
        {
            _itemRepository.Insert(item);
            return Ok();
        }

        [HttpDelete("/api/items/{id}")]
        public ActionResult DeleteItem(int id)
        {
            _itemRepository.Delete(id);
            return Ok();
        }
    }
}
