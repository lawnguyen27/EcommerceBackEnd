using ShopLibrary.BussinessObject;
using ShopLibrary.DataAccess;
using ShopLibrary.Repository.Interface;
using System;
using System.Collections.Generic;

namespace ShopLibrary.Repository
{
    public class SizeRepository : ISizeRepository
    {
        public IEnumerable<Size> GetSizes(int pageNumber, int pageSize) => SizeManagement.Instance.GetSizeList(pageNumber, pageSize);
        public IEnumerable<Size> GetSizes() => SizeManagement.Instance.GetSizeList();

        public Size GetSizeByID(int sizeId) => SizeManagement.Instance.GetSizeByID(sizeId);
        public void InsertSize(Size size) => SizeManagement.Instance.AddNew(size);
        public void DeleteSize(Size size) => SizeManagement.Instance.Remove(size);
        public void UpdateSize(Size size) => SizeManagement.Instance.Update(size);
    }
}
