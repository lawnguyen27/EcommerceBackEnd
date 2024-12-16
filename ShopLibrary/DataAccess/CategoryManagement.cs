using Microsoft.EntityFrameworkCore;
using ShopLibrary.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.DataAccess
{
    public class CategoryManagement
    {
        private static CategoryManagement instance = null;
        private static readonly object instanceLock = new object();

        private CategoryManagement()
        {
        }

        public static CategoryManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CategoryManagement();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Category> GetCategoryList(int pageNumber, int pageSize)
        {
            List<Category> categories;
            try
            {
                var DB = new EcommerceDbContext();
                categories = DB.Categories
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return categories;
        }
        public IEnumerable<Category> GetCategoryList()
        {
            List<Category> categories;
            try
            {
                var DB = new EcommerceDbContext();
                categories = DB.Categories.ToList();
                  
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return categories;
        }
        public Category GetCategoryByID(int categoryId)
        {
            Category category = null;
            try
            {
                var DB = new EcommerceDbContext();
                category = DB.Categories.SingleOrDefault(x => x.CategoryId == categoryId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return category;
        }

        public void AddNew(Category category)
        {
            try
            {
                Category existingCategory = GetCategoryByID(category.CategoryId);
                if (existingCategory == null)
                {
                    var DB = new EcommerceDbContext();
                    DB.Categories.Add(category);
                    DB.SaveChanges();
                }
                else
                {
                    throw new Exception("Category already exists!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Category category)
        {
            try
            {
                Category existingCategory = GetCategoryByID(category.CategoryId);
                if (existingCategory != null)
                {
                    var DB = new EcommerceDbContext();
                    DB.Entry<Category>(category).State = EntityState.Modified;
                    DB.SaveChanges();
                }
                else
                {
                    throw new Exception("Category does not exist!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(Category category)
        {
            try
            {
                Category existingCategory = GetCategoryByID(category.CategoryId);
                if (existingCategory != null)
                {
                    var DB = new EcommerceDbContext();
                    DB.Categories.Remove(existingCategory);
                    DB.SaveChanges();
                }
                else
                {
                    throw new Exception("Category does not exist!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
