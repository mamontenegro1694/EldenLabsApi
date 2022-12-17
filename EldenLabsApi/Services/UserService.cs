using EldenLabsApi.Database.Entities;
using EldenLabsApi.DTOs;
using EldenLabsApi.Repositories.Interfaces;
using EldenLabsApi.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace EldenLabsApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetByEmailAndPassword(string email, string password)
        {
            var user = await _userRepository.GetByEmail(email);

            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return null;
            }

            return user;
        }

        public Task<User> Create(CreateUserDTO createUser)
        {
            return _userRepository.Create(
                createUser.Email,
                BCrypt.Net.BCrypt.HashPassword(createUser.Password)
            );
        }
    }
}
