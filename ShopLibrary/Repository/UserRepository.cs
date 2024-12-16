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
    public class UserRepository:IUserRepository
    {
        public IEnumerable<User> GetUsers() => UserManagement.Instance.GetUserList();
        public User GetUserByID(int uid) => UserManagement.Instance.GetUserByID(uid);
        public void InsertUser(User u) => UserManagement.Instance.AddNew(u);
        public void DeleteUser(User u) => UserManagement.Instance.Remove(u);
        public void UpdateUser(User u) => UserManagement.Instance.Update(u);
        public User Login(string email, string password) => UserManagement.Instance.Login (email,password);

        public User GetUserByEmail(string email) => UserManagement.Instance.GetUserByEmail(email);
    }
}
