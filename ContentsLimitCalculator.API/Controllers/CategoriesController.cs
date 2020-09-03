using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NudeSol.ContentLimitInsurance.WebAPI.Data;
using NudeSol.ContentLimitInsurance.WebAPI.Models;

namespace NudeSol.ContentLimitInsurance.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("/api/categories")]
        public IEnumerable GetCategories()
        {
            var categories = _categoryRepository.GetAll();
            return categories;
        }

        [HttpGet("/api/categories/{categoryId}")]
        public Category getCategoryById(int categoryId)
        {
            return _categoryRepository.GetCategoryById(categoryId);
        }
    }
}
