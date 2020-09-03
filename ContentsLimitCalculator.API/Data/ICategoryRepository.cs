using NudeSol.ContentLimitInsurance.WebAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NudeSol.ContentLimitInsurance.WebAPI.Data
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();

        Category GetCategoryById(int categoryId);

        IList GetAsKeyValuePairs();

        void Insert(Category category);

        void Update(Category category);

        void Delete(Category category);
    }
}
