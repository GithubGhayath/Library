using Library.Application.Reopsitories.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Library.API.Controllers.Auth
{
    [ApiController]
    [Route("api/[controller]")] // Rout: https://localhost:7170/api/Auth/login
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _IUnitOfWork;
        public AuthController(IUnitOfWork IUnitOfWork)
        {
            _IUnitOfWork = IUnitOfWork;
        }



        [HttpPost("login")]
        public IActionResult Login([FromBody] Application.Features.Auth.Dtos.LoginRequest request)
        {

            var User = _IUnitOfWork.UserRepository.Get(u => u.Person.Email!.Value == request.Email, include: query => query.Include(u => u.Person));
              
            if (User == null)
                return Unauthorized("Invalid credentials");

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(request.Password, User.Password);


            if (!isValidPassword)
                return Unauthorized("Invalid credentials");


            var claims = new[]
            {
                // Unique identifier for the student
                new Claim(ClaimTypes.NameIdentifier, User.Id.ToString()),


                // Student email address
                new Claim(ClaimTypes.Email, User.Person.Email!.Value),


                // Role (Student or Admin) used later for authorization
                new Claim(ClaimTypes.Role, User.Role)
            };


            // Step 4: Create the symmetric security key used to sign the JWT.
            // This key must match the key used in JWT validation middleware.
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("THIS_IS_A_VERY_SECRET_KEY_123456"));


            // Step 5: Define the signing credentials.
            // This specifies the algorithm used to sign the token.
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            // Step 6: Create the JWT token.
            // The token includes issuer, audience, claims, expiration, and signature.
            var token = new JwtSecurityToken(
                issuer: "LibraryApi",
                audience: "LibraryApiUsers",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );


            // Step 7: Return the serialized JWT token to the client.
            // The client will send this token with future requests.
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
