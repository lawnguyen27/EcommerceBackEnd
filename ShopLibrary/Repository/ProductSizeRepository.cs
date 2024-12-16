using ShopLibrary.BussinessObject;
using ShopLibrary.DataAccess;
using ShopLibrary.Repository.Interface;
using System.Collections.Generic;

namespace ShopLibrary.Repository
{
    public class ProductSizeRepository : IProductSizeRepository
    {
        public IEnumerable<ProductSize> GetAllProductSizes() => ProductSizeManagement.Instance.GetProductSizeList();

        public IEnumerable<ProductSize> GetProductSizesByProductId(int productId) => ProductSizeManagement.Instance.GetSizeOfProductById(productId);

        public ProductSize GetProductSizeById(int productId, int sizeId) => ProductSizeManagement.Instance.GetProductSizeByID(productId, sizeId);

        public void InsertProductSize(ProductSize productSize) => ProductSizeManagement.Instance.AddNew(productSize);

        public void UpdateProductSize(ProductSize productSize) => ProductSizeManagement.Instance.Update(productSize);

        public void DeleteProductSize(ProductSize productSize) => ProductSizeManagement.Instance.Remove(productSize);
    }
}

