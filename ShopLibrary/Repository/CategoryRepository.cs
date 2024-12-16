using ShopLibrary.BussinessObject;
using ShopLibrary.DataAccess;
using ShopLibrary.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> GetCategories(int pageNumber, int pageSize) => CategoryManagement.Instance.GetCategoryList(pageNumber, pageSize);
        public IEnumerable<Category> GetCategories() => CategoryManagement.Instance.GetCategoryList();

        public Category GetCategoryByID(int categoryId) => CategoryManagement.Instance.GetCategoryByID(categoryId);
        public void InsertCategory(Category category) => CategoryManagement.Instance.AddNew(category);
        public void DeleteCategory(Category category) => CategoryManagement.Instance.Remove(category);
        public void UpdateCategory(Category category) => CategoryManagement.Instance.Update(category);
    }
}

