using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.Service
{
    public class PasswordService
    {
        private readonly PasswordHasher<string> _passwordHasher = new PasswordHasher<string>();

        // Mã hóa mật khẩu
        public string HashPassword(string plainPassword)
        {
            return _passwordHasher.HashPassword(null, plainPassword);
        }

        // Kiểm tra mật khẩu nhập vào với mật khẩu đã mã hóa
        public bool VerifyPassword(string hashedPassword, string plainPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, plainPassword);
            return result == Microsoft.AspNetCore.Identity.PasswordVerificationResult.Success;
        }
    }
}
