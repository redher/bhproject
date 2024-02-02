using Company.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        public Task<Account?> GetAccountByCustomerIdWithTransactionsAsync(Guid customerId);
    }
}
