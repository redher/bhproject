using BlueHarvest.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAll();
        Task<Account> GetAccountByCustomerId(Guid customerId);
        Task<Account> CreateAccount(Guid customerId, decimal transactionValue);
        Task UpdateAccount(Account accountToBeUpdated, Account account);
    }
}
