using Microsoft.EntityFrameworkCore;
using ShopLibrary.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.DataAccess
{
    public class ProductManagement
    {
        private static ProductManagement instance = null;
        private static readonly object instanceLock = new object();

        private ProductManagement()
        {
        }

        public static ProductManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductManagement();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Product> GetProductList(int pageNumber, int pageSize)
        {
            List<Product> products;
            try
            {
                var DB = new EcommerceDbContext();
                products = DB.Products
                    .Include(p=>p.ProductSizes)
                    .Include(p => p.ProductImages)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public Product GetProductByID(int productId)
        {
            Product product = null;
            try
            {
                var DB = new EcommerceDbContext();
                product = DB.Products
                    .Include(p => p.ProductSizes)
                    .Include(p => p.ProductImages)
                    .SingleOrDefault(x => x.ProductId == productId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }
        public IEnumerable<Product> GetProductListBySex(int pageNumber, int pageSize, string sex)
        {
            List<Product> products;
            try
            {
                var DB = new EcommerceDbContext();
                products = DB.Products
                .Include(p => p.ProductSizes)
                .Include(p => p.ProductImages)
                .Where(p => p.Category.CategoryType.Name == sex) // Lọc sản phẩm theo thuộc tính 'Sex'
                .Skip((pageNumber - 1) * pageSize) // Bỏ qua sản phẩm trước trang hiện tại
                .Take(pageSize) // Lấy số lượng sản phẩm theo kích thước trang
                .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching products by sex: " + ex.Message);
            }
            return products;
        }
        public IEnumerable<Product> GetProductListByCategory(int pageNumber, int pageSize, int cateid)
        {
            List<Product> products;
            try
            {
                var DB = new EcommerceDbContext();
                products = DB.Products
                .Include(p => p.ProductSizes)
                .Include(p => p.ProductImages)
                .Where(p => p.CategoryId==cateid) // Lọc sản phẩm theo thuộc tính 'categoryid'
                .Skip((pageNumber - 1) * pageSize) // Bỏ qua sản phẩm trước trang hiện tại
                .Take(pageSize) // Lấy số lượng sản phẩm theo kích thước trang
                .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching products by sex: " + ex.Message);
            }
            return products;
        }
        public Product AddNew(Product product)
        {
            try
            {
                Product existingProduct = GetProductByID(product.ProductId);
                if (existingProduct == null)
                {
                    var DB = new EcommerceDbContext();
                    DB.Products.Add(product);
                    DB.SaveChanges();
                }
                else
                {
                    throw new Exception("Product already exists!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }

        public void Update(Product product)
        {
            try
            {
                Product existingProduct = GetProductByID(product.ProductId);
                if (existingProduct != null)
                {
                    var DB = new EcommerceDbContext();
                    DB.Entry<Product>(product).State = EntityState.Modified;
                    DB.SaveChanges();
                }
                else
                {
                    throw new Exception("Product does not exist!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(Product product)
        {
            try
            {
                Product existingProduct = GetProductByID(product.ProductId);
                if (existingProduct != null)
                {
                    var DB = new EcommerceDbContext();
                    DB.Products.Remove(existingProduct);
                    DB.SaveChanges();
                }
                else
                {
                    throw new Exception("Product does not exist!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

