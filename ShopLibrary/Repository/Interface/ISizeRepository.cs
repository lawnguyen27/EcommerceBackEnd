using ShopLibrary.BussinessObject;
using System.Collections.Generic;

namespace ShopLibrary.Repository.Interface
{
    public interface ISizeRepository
    {
        IEnumerable<Size> GetSizes(int pageNumber, int pageSize); // Retrieve paginated list of sizes
        IEnumerable<Size> GetSizes(); // Retrieve all sizes
        Size GetSizeByID(int sizeId); // Retrieve size by ID
        void InsertSize(Size size); // Insert a new size
        void DeleteSize(Size size); // Delete an existing size
        void UpdateSize(Size size); // Update an existing size
    }
}
