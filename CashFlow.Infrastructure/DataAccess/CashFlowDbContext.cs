﻿using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess
{
    internal class CashFlowDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }

        public CashFlowDbContext(DbContextOptions options) : base(options) {}
    }
}