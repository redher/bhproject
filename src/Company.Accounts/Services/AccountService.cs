﻿using Company.Core.Models;
using Company.Core.Interfaces;
using Company.Core.Services;

namespace Company.Accounts.Api.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task CreateAccount(Guid customerId, decimal initialCredit)
        {
            var transactions = new List<Transaction>();
            if (initialCredit != 0)
            {
                transactions.Add(new Transaction() { Value = initialCredit });
            }

            await _unitOfWork.Accounts.AddAsync(
                new Account() { 
                    Id = Guid.NewGuid(),
                    CustomerId = customerId, 
                    Transactions = transactions 
                });

            await _unitOfWork.CommitAsync();
        }

        public async Task<Account?> GetAccountByCustomerId(Guid customerId)
        {
            return await _unitOfWork.Accounts.GetAccountByCustomerIdWithTransactionsAsync(customerId);
        }
    }
}
