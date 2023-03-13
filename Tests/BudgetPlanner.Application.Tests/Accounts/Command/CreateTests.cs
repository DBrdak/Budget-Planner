﻿using Application.Accounts;
using Application.DTO;
using Application.Interfaces;
using Application.Tests.Common;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;

namespace Application.Tests.Account
{
    public class CreateTests : CommandTestBase
    {
        private Mock<IBudgetAccessor> _budgetAccessorMock;

        public CreateTests()
        {
            _budgetAccessorMock = new Mock<IBudgetAccessor>();
        }

        [Fact]
        public async Task ShouldCreateAccount()
        {
            //Arrange
            var user = await _context.Users.FirstAsync();
            var budget = await _context.Budgets.FirstAsync();

            _budgetAccessorMock.Setup(x => x.GetBudgetId()).ReturnsAsync(budget.Id);

            var accountToCreate = new AccountDto
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                AccountType = "Checking",
                Balance = 1000,
            };

            var handler = new Create.Handler(_context, _mapper, _budgetAccessorMock.Object);

            //Act
            var result = await handler.Handle
                (new Create.Command { NewAccount = accountToCreate }, CancellationToken.None);

            //Assert
            var accountInDb = await _context.Accounts.FindAsync(accountToCreate.Id);

            result.IsSuccess.ShouldBe(true);
            accountInDb.ShouldNotBeNull();
            //accountInDb.Name.ShouldBe(accountToCreate.Name);
            //accountInDb.AccountType.ShouldBe(accountToCreate.AccountType);
            //accountInDb.Balance.ShouldBe(accountToCreate.Balance);
            //accountInDb.Budget.ShouldBe(budget);
        }
    }
}