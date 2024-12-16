using Microsoft.EntityFrameworkCore;
using ShopLibrary.BussinessObject;
using ShopLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.DataAccess
{
    public class UserManagement
    {
        private static UserManagement instance = null;
        private static readonly object instanceLock = new object();
        private PasswordService passwordService = new PasswordService();
        private UserManagement()
        {

        }
        public static UserManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new UserManagement();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<User> GetUserList()
        {
            List<User> users;
            try
            {
                var DB = new EcommerceDbContext();
                users = DB.Users.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return users;
        }
        public User GetUserByID(int userId)
        {
            User user = null;
            try
            {
                var DB = new EcommerceDbContext();
                user = DB.Users.SingleOrDefault(x => x.UserId == userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }
        public User GetUserByEmail(string email)
        {
            User user = null;
            try
            {
                var DB = new EcommerceDbContext();
                user = DB.Users.SingleOrDefault(x => x.Email.Equals(email));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }
        public void AddNew(User user)
        {
            try
            {
                User _user = GetUserByID(user.UserId);
                if (_user == null)
                {
                    user.Password= passwordService.HashPassword(user.Password);
                    var DB = new EcommerceDbContext();
                    DB.Users.Add(user);
                    DB.SaveChanges();
                }
                else
                {
                    throw new Exception("User already exists!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(User user)
        {
            try
            {
                User u = GetUserByID(user.UserId);
                if (u != null)
                {
                    user.Password = passwordService.HashPassword(user.Password);
                    var DB = new EcommerceDbContext();
                    DB.Entry<User>(user).State = EntityState.Modified;
                    DB.SaveChanges();
                }
                else
                {
                    throw new Exception("User does not exist!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Remove(User user)
        {
            try
            {
                User _user = GetUserByID(user.UserId);
                if (_user != null)
                {
                    var DB = new EcommerceDbContext();
                    DB.Users.Remove(_user);
                    DB.SaveChanges();
                }
                else
                {
                    throw new Exception("User does not exist!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public User Login(string email, string password)
        {
            User _user = GetUserByEmail(email);
                if (_user != null //&& password.Equals(_user.Password)
                && passwordService.VerifyPassword(_user.Password,password)
                )
                {
                   return _user;
                }
                else
                {
                return null;
                }
        }

    }
}