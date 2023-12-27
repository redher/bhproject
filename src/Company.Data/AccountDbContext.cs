using Company.Core.Models;
using Company.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Company.Data
{
    public class AccountDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public AccountDbContext(DbContextOptions<AccountDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new AccountConfiguration());

            builder
                .ApplyConfiguration(new TransactionConfiguration());
        }
    }
}
