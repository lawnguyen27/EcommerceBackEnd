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
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetProducts(int pageNumber, int pageSize) => ProductManagement.Instance.GetProductList(pageNumber, pageSize);
        public Product GetProductByID(int pid) => ProductManagement.Instance.GetProductByID(pid);
        public IEnumerable<Product> GetProductListBySex(int pageNumber, int pageSize,string sex) => ProductManagement.Instance.GetProductListBySex(pageNumber, pageSize,sex);
        public IEnumerable<Product> GetProductListByCategory(int pageNumber, int pageSize, int cateid) => ProductManagement.Instance.GetProductListByCategory(pageNumber, pageSize, cateid);

        public Product InsertProduct(Product p) => ProductManagement.Instance.AddNew(p);
        public void DeleteProduct(Product p) => ProductManagement.Instance.Remove(p);
        public void UpdateProduct(Product p) => ProductManagement.Instance.Update(p);
    }
}
