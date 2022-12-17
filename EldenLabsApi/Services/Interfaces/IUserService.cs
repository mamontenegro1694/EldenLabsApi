using EldenLabsApi.Database.Entities;
using EldenLabsApi.DTOs;

namespace EldenLabsApi.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetByEmailAndPassword(string email, string password);

        public Task<User> Create(CreateUserDTO createUser);
    }
}
