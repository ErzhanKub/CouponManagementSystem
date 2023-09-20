using Domain.Entities;
using Domain.Repositories;
using Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(User entity)
        {
            await _dbContext.Users.AddAsync(entity);
        }

        public void Delete(string username)
        {
            _dbContext.Remove(username);
        }

        public Task<List<User>> GetAllAsync()
        {
            return _dbContext.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            var result = await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == username);
            return result;
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
