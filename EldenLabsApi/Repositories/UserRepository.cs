using EldenLabsApi.Database;
using EldenLabsApi.Database.Entities;
using EldenLabsApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EldenLabsApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<User> GetByEmail(string email)
        {
            return _dbContext.Users?.Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public async Task<User> Create(string email, string password)
        {
            var userCreated = new User()
            {
                Email = email,
                Password = password
            };

            await _dbContext.Users.AddAsync(userCreated);
            await _dbContext.SaveChangesAsync();

            return userCreated;
        }
    }
}
