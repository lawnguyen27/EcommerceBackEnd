using ShopLibrary.BussinessObject;
using ShopLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.Repository.Interface
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts(int pageNumber, int pageSize);
        Product GetProductByID(int productId);
        IEnumerable<Product> GetProductListBySex(int pageNumber, int pageSize,string sex);

        Product InsertProduct(Product product);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);
    }
}
