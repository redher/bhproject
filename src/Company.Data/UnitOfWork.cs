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

        public UnitOfWork(AccountDbContext context)
        {
            this._context = context;
            accountRepository = new AccountRepository(_context);
        }

        public IAccountRepository Accounts => accountRepository;

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