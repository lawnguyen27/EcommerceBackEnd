using ShopLibrary.BussinessObject;
using ShopLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserByID(int uid);
        void InsertUser(User u);
        void DeleteUser(User u);
        void UpdateUser(User u);
        User GetUserByEmail(string email);
        User Login(string email, string password);

    }
}
