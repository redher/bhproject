using Company.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Services
{
    public interface IAccountService
    {
        Task<Account?> GetAccountByCustomerId(Guid customerId);
        Task CreateAccount(Guid customerId, decimal initialCredit);
    }
}
