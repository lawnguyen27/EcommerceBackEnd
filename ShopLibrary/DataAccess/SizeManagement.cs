using Microsoft.EntityFrameworkCore;
using ShopLibrary.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopLibrary.DataAccess
{
    public class SizeManagement
    {
        private static SizeManagement instance = null;
        private static readonly object instanceLock = new object();

        private SizeManagement()
        {
        }

        public static SizeManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new SizeManagement();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Size> GetSizeList(int pageNumber, int pageSize)
        {
            List<Size> sizes;
            try
            {
                var DB = new EcommerceDbContext();
                sizes = DB.Sizes
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return sizes;
        }

        public IEnumerable<Size> GetSizeList()
        {
            List<Size> sizes;
            try
            {
                var DB = new EcommerceDbContext();
                sizes = DB.Sizes.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return sizes;
        }

        public Size GetSizeByID(int sizeId)
        {
            Size size = null;
            try
            {
                var DB = new EcommerceDbContext();
                size = DB.Sizes.SingleOrDefault(x => x.Id == sizeId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return size;
        }      
        public void AddNew(Size size)
        {
            try
            {
                Size existingSize = GetSizeByID(size.Id);
                if (existingSize == null)
                {
                    var DB = new EcommerceDbContext();
                    DB.Sizes.Add(size);
                    DB.SaveChanges();
                }
                else
                {
                    throw new Exception("Size already exists!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Size size)
        {
            try
            {
                Size existingSize = GetSizeByID(size.Id);
                if (existingSize != null)
                {
                    var DB = new EcommerceDbContext();
                    DB.Entry<Size>(size).State = EntityState.Modified;
                    DB.SaveChanges();
                }
                else
                {
                    throw new Exception("Size does not exist!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(Size size)
        {
            try
            {
                Size existingSize = GetSizeByID(size.Id);
                if (existingSize != null)
                {
                    var DB = new EcommerceDbContext();
                    DB.Sizes.Remove(existingSize);
                    DB.SaveChanges();
                }
                else
                {
                    throw new Exception("Size does not exist!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
