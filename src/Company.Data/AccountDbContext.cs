using Company.Core.Models;
using Company.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Company.Data
{
    public class AccountDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Transaction> Customers { get; set; }

        public AccountDbContext(DbContextOptions<AccountDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AccountConfiguration());

            builder.ApplyConfiguration(new TransactionConfiguration());

            builder.ApplyConfiguration(new CustomerConfiguration());

            builder.Entity<Customer>().HasData(
                new Customer()
                {
                    Id = new Guid("0ed6e835-5bdd-4e58-9c0d-dff1c2a3cba6"),
                    FirstName = "Jeff",
                    LastName = "Mills"
                },
                new Customer()
                {
                    Id = new Guid("ff1b99bb-e2cf-4fd0-8879-08f96e3713a7"),
                    FirstName = "Sven",
                    LastName = "Vath"
                }
            );

        }
    }
}
