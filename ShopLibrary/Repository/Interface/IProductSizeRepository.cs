using ShopLibrary.BussinessObject;
using System.Collections.Generic;

namespace ShopLibrary.Repository.Interface
{
    public interface IProductSizeRepository
    {
        IEnumerable<ProductSize> GetAllProductSizes();
        IEnumerable<ProductSize> GetProductSizesByProductId(int productId);
        ProductSize GetProductSizeById(int productId, int sizeId);
        void InsertProductSize(ProductSize productSize);
        void UpdateProductSize(ProductSize productSize);
        void DeleteProductSize(ProductSize productSize);
    }
}
