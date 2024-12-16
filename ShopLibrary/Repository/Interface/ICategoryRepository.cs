using ShopLibrary.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.Repository.Interface
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories(int pageNumber, int pageSize);
        IEnumerable<Category> GetCategories();
        Category GetCategoryByID(int categoryId);
        void InsertCategory(Category category);
        void DeleteCategory(Category category);
        void UpdateCategory(Category category);
    }
}

