﻿using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Validation
{
    // Export functions to other classes

    public class ValidationExtension : IValidationExtension
    {
        private readonly DataContext _context;
        private readonly IUserAccessor _userAccessor;
        private readonly IBudgetAccessor _budgetAccessor;

        public ValidationExtension(DataContext context, IUserAccessor userAccessor, IBudgetAccessor budgetAccessor)
        {
            _context = context;
            _userAccessor = userAccessor;
            _budgetAccessor = budgetAccessor;
        }

        public async Task<bool> UniqueBudgetName(string newBudgetName)
        {
            var budgetName = await _budgetAccessor.GetBudgetName();

            return await _context.Budgets
                .AsNoTracking()
                .Where(b => b.Name != budgetName)
                .AnyAsync(b => b.Name.ToUpper() == newBudgetName.ToUpper());
        }

        public async Task<bool> UniqueEmail(string newEmail)
        {
            return await _context.Users
                .AsNoTracking()
                .Where(u => u.UserName != _userAccessor.GetUsername())
                .AnyAsync(u => u.NormalizedEmail == newEmail.ToUpper());
        }

        public async Task<bool> UniqueUsername(string newUsername)
        {
            return await _context.Users
                .AsNoTracking()
                .Where(u => u.UserName != _userAccessor.GetUsername())
                .AnyAsync(u => u.NormalizedUserName == newUsername.ToUpper());
        }

        public async Task<bool> UniqueCategory(string categoryName, string categoryType)
        {
            var budgetId = await _budgetAccessor.GetBudgetId();

            return !await _context.TransactionCategories
                .AsNoTracking()
                .Where(tc => tc.Type == categoryType
                    && tc.BudgetId == budgetId)
                .AnyAsync(tc => tc.Value.ToUpper() == categoryName.ToUpper());
        }

        public async Task<bool> AccountExists(string accountName)
        {
            var budgetId = await _budgetAccessor.GetBudgetId();

            return await _context.Accounts
                .AsNoTracking()
                .Where(a => a.BudgetId == budgetId)
                .AnyAsync(a => a.Name == accountName);
        }

        public async Task<bool> AccountTypeOf(string accountName, string accountType)
        {
            var budgetId = await _budgetAccessor.GetBudgetId();

            var account = await _context.Accounts
                .AsNoTracking()
                .Where(a => a.BudgetId == budgetId)
                .FirstOrDefaultAsync(a => a.Name == accountName);

            if (account == null)
                return false;

            return account.AccountType == accountType;
        }

        public async Task<bool> GoalExists(string goalName)
        {
            var budgetId = await _budgetAccessor.GetBudgetId();

            return await _context.Goals
                .AsNoTracking()
                .Where(g => g.BudgetId == budgetId)
                .AnyAsync(g => g.Name == goalName);
        }

        public async Task<bool> UniqueGoalName(string goalName)
        {
            var budgetId = await _budgetAccessor.GetBudgetId();

            return !await _context.Goals
                .AsNoTracking()
                .Where(g => g.BudgetId == budgetId)
                .AnyAsync(g => g.Name == goalName);
        }
    }
}