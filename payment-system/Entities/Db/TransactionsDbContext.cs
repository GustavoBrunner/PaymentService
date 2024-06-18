using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace payment_system.Entities.Db
{
    public class TransactionsDbContext : DbContext
    {
        public DbSet<TransactionModel> Transactions { get; set; }
        public DbSet<UserDto> Users { get; set; }
        public TransactionsDbContext(DbContextOptions<TransactionsDbContext> options):base(options) {}

        protected override void OnModelCreating(ModelBuilder mB)
        {
            //transactions configs
            mB.Entity<TransactionModel>().ToTable("Transaction");
            mB.Entity<TransactionModel>().HasKey(t => new {t.TransactionId, t.UserId, t.ReceiverId});

        }
    }
}