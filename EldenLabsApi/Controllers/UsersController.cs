using EldenLabsApi.Database.Entities;
using EldenLabsApi.DTOs;
using EldenLabsApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EldenLabsApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create([FromBody] CreateUserDTO createUser)
        {
            return await _userService.Create(createUser);
        }

        [HttpGet("me")]
        public User GetMe()
        {
            return new User
            {
                Email = "mmontenegro@celsia.com",
                Password = null
            };
        }
    }
}
