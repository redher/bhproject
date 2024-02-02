using Company.Core.Interfaces;
using Company.Core.Repositories;
using Company.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AccountDbContext _context;
        private AccountRepository accountRepository;
        private CustomerRepository customerRepository;

        public UnitOfWork(AccountDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
            accountRepository = new AccountRepository(_context);
            customerRepository = new CustomerRepository(_context);
        }

        public IAccountRepository Accounts => accountRepository;
        public ICustomerRepository Customers => customerRepository;

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}