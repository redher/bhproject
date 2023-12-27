using Company.Accounts.Api.Services;
using Company.Core.Interfaces;
using Company.Core.Services;
using Company.Data;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
namespace Company.Accounts.Api.Tests.Services
{
    [TestFixture]
    public class AccountServiceTests
    {
        IAccountService accountService;
        public AccountServiceTests()
        {
            var options = new DbContextOptionsBuilder<AccountDbContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
            .Options;

            var accountDbContext = new AccountDbContext(options);
            IUnitOfWork unitOfWork = new UnitOfWork(accountDbContext);
            accountService = new AccountService(unitOfWork);
        }

        [Test]
        public async Task CreateAccount_ShouldAddAccount() { 
            //Arrange
            var customerId = Guid.NewGuid();
            var transactionValue = 0;

            //Act
            await accountService.CreateAccount(customerId, transactionValue);

            //Assert
            var account = await accountService.GetAccountByCustomerId(customerId);
            account.Should().NotBeNull();
            account!.CustomerId.Should().Be(customerId);
            account.Transactions!.Count().Should().Be(0);
        }
    }
}
