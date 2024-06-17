using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using payment_system.Entities;

namespace user_api.Repositories
{
    public interface IUserRepository
    {
        Task<User> FindByIdAsync(string id);
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<bool> DeleteUser(string id);

        Task<bool> SaveChangesAsync();
        bool CheckIfUserExists(string id);
    }
}