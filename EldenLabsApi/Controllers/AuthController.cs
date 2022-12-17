using EldenLabsApi.Database.Entities;
using EldenLabsApi.DTOs;
using EldenLabsApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EldenLabsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IUserService _userService;

        public AuthController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        public async Task<IActionResult> Login([FromBody] LoginUserDTO userLogin)
        {
            if (userLogin == null || (userLogin.Email == null || userLogin.Password == null))
            {
                return BadRequest();
            }

            var authUser = await _userService.GetByEmailAndPassword(
                userLogin.Email,
                userLogin.Password
            );

            if (authUser == null)
            {
                return BadRequest("Invalid credentials");
            }

            //create claims details based on the user information
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("Email", authUser.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: signIn
            );

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
