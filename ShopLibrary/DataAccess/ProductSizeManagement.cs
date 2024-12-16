using Microsoft.EntityFrameworkCore;
using ShopLibrary.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopLibrary.DataAccess
{
    public class ProductSizeManagement
    {
        private static ProductSizeManagement instance = null;
        private static readonly object instanceLock = new object();

        private ProductSizeManagement()
        {
        }

        public static ProductSizeManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductSizeManagement();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<ProductSize> GetProductSizeList()
        {
            List<ProductSize> productSizes;
            try
            {
                var DB = new EcommerceDbContext();
                productSizes = DB.ProductSizes.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productSizes;
        }

        public IEnumerable<ProductSize> GetSizeOfProductById(int productId)
        {
            List<ProductSize> productSizes;
            try
            {
                var DB = new EcommerceDbContext();
                productSizes = DB.ProductSizes
                     .Where(x => x.ProductId == productId)
                     .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productSizes;
        }
        public ProductSize GetProductSizeByID(int productId,int sizeid)
        {
            ProductSize productSizes;
            try
            {
                var DB = new EcommerceDbContext();
                productSizes = DB.ProductSizes
                     .SingleOrDefault(x => x.ProductId == productId&& x.SizeId==sizeid);
                     
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productSizes;
        }
        public void AddNew(ProductSize productSize)
        {
            try
            {
                ProductSize existingProductSize = GetProductSizeByID(productSize.ProductId,productSize.SizeId);
                if (existingProductSize == null)
                {
                    var DB = new EcommerceDbContext();
                    DB.ProductSizes.Add(productSize);
                    DB.SaveChanges();
                }
                else
                {
                    throw new Exception("ProductSize already exists!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(ProductSize productSize)
        {
            try
            {
                ProductSize existingProductSize = GetProductSizeByID(productSize.ProductId, productSize.SizeId);
                if (existingProductSize != null)
                {
                    var DB = new EcommerceDbContext();
                    DB.Entry<ProductSize>(productSize).State = EntityState.Modified;
                    DB.SaveChanges();
                }
                else
                {
                    throw new Exception("ProductSize does not exist!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(ProductSize productSize)
        {
            try
            {
                ProductSize existingProductSize = GetProductSizeByID(productSize.ProductId, productSize.SizeId);
                if (existingProductSize != null)
                {
                    var DB = new EcommerceDbContext();
                    DB.ProductSizes.Remove(existingProductSize);
                    DB.SaveChanges();
                }
                else
                {
                    throw new Exception("ProductSize does not exist!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
