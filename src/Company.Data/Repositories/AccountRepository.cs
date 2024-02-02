using Company.Core.Models;
using Company.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(AccountDbContext context) : base(context) { }

        public async Task<Account?> GetAccountByCustomerIdWithTransactionsAsync(Guid customerId)
        {
            return await AccountDbContext.Accounts
                .Include(x => x.Transactions)
                .FirstOrDefaultAsync(x => x.CustomerId.Equals(customerId));
        }

        private AccountDbContext AccountDbContext { get { return (AccountDbContext)Context; } }

    }
}
