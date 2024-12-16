using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Core.Types;
using ShopAPI.Request;
using ShopLibrary.BussinessObject;
using ShopLibrary.Repository;
using ShopLibrary.Repository.Interface;
using ShopLibrary.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Caching.Memory;
using ResetPasswordRequest = ShopAPI.Request.ResetPasswordRequest;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepository userRepository=new UserRepository();
        EmailService emailService = new EmailService();
        // GET: api/<UserController>
        [HttpPost("Login")]
        public ActionResult Login([FromBody]Request.LoginRequest loginRequest)
        {
            User user = userRepository.Login(loginRequest.Email,loginRequest.Password);
            if (user != null)
            {
                var token = GenerateJwtToken(user);
                return Ok(new { Token = token });
            }

            return Unauthorized("Invalid credentials");
        }
        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsAVeryStrongSecretKeyWithAtLeast32Chars!"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, user.Role)  // Adding role claim
        };

            var token = new JwtSecurityToken(
                issuer: "yourIssuer",
                audience: "yourAudience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(1440), // Set expiration as needed
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpPost("Register")]
        public ActionResult Register([FromBody] Request.RegisterRequest registerRequest)
        {
            User user = new User();
            user.Email = registerRequest.Email;
            user.Password = registerRequest.Password;
            user.Address = registerRequest.Address;
            user.PhoneNumber=registerRequest.Phone;
            user.Name= registerRequest.Name;
            user.Role = "customer";
            user.CreatedAt = DateTime.Now;
            try 
            {
                userRepository.InsertUser(user);
                return Ok(registerRequest);

            }
            catch
            {
                return BadRequest("Fail to register");
            }

        }
        [Authorize(Roles ="admin")]
        [HttpGet]
        public ActionResult<IQueryable<User>> Get()
        {
            return Ok(userRepository.GetUsers()) ;
        }

        // GET api/<UserController>/5
        [Authorize]
        [HttpGet("{email}")]
        public ActionResult Get([FromRoute] string email)
        {
            var user = userRepository.GetUserByEmail(email);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/<UserController>


        // PUT api/<UserController>/5
        [Authorize]

        [HttpPut("{key}")]
        public ActionResult Put([FromRoute] string key, [FromBody] UpdateUserRequest updateUser)
        {
            var u = userRepository.GetUserByEmail(key);

            if (u == null)
            {
                return NotFound();
            }
            if(updateUser !=null)
            {
                u.Name = updateUser.Name;
                u.Email = updateUser.Email;
                u.PhoneNumber = updateUser.Phone;
                u.Address = updateUser.StreetAddress +" "+ updateUser.City+" " + updateUser.Country;
                u.UpdatedAt= DateTime.Now;
            }    
            userRepository.UpdateUser(u);

            return Ok(u) ;
        }

        // DELETE api/<UserController>/5
        [Authorize]

        [HttpDelete("{key}")]
        public ActionResult Delete([FromRoute] int key)
        {
            var user = userRepository.GetUserByID(key);

            if (user != null)
            {
                userRepository.DeleteUser(user);
            }
            return Ok("Success");
        }
        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> RequestPasswordReset([FromBody] ResetPasswordRequest model)
        {
            if (model.Email == null || userRepository.GetUserByEmail(model.Email)==null)
            {
                return BadRequest("Invalid request data. Email cannot be null.");
            }
            var otpCode = new Random().Next(100000, 999999).ToString();
            await emailService.SendEmailAsync(model.Email, "Password Reset OTP",
                $"Your OTP code is {otpCode}.");

            return Ok(otpCode);
        }
        [HttpPut("Password")]
        public IActionResult VerifyOtpAndResetPassword([FromBody] ChangePasswordModel model)
        {
           var user = userRepository.GetUserByEmail(model.Email);
            if (user != null)
            {
                user.Password= model.Password;
                userRepository.UpdateUser(user); 
            }
            return Ok("Password successfully reset.");
        }
    }
}
