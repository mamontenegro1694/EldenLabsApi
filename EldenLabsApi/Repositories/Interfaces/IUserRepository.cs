using EldenLabsApi.Database.Entities;

namespace EldenLabsApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> GetByEmail(string email);

        public Task<User> Create(string email, string password);
    }
}
