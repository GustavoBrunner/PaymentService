using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using payment_system.Entities;
using user_api.Entities.Db;

namespace user_api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _context.AddAsync(user);
            if(await SaveChangesAsync()){
                return user;
            }
            return null;
        }

        public async Task<bool> DeleteUser(string id)
        {
            var user = await FindByIdAsync(id);
            _context.Users.Remove(user);
            if(await SaveChangesAsync())
                return true;
            else
                return false;
        }

        public async Task<User> FindByIdAsync(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            if(await SaveChangesAsync())
                return user;
            else 
                return null;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool CheckIfUserExists(string id)
        {
            return _context.Users.Any(u => u.UserId == id);
        }
    }
}