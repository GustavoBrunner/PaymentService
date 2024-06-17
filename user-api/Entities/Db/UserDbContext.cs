using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace user_api.Entities.Db
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options){}
    }
}