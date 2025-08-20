﻿using CashFlow.Domain.Repositories;
using CashFlow.Infrastructure.DataAccess;

namespace CashFlow.Infrastructure.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly CashFlowDbContext _dbContext;
        public UnitOfWork(CashFlowDbContext dbContext)
        {
               _dbContext = dbContext;
        }
        public void Commit() => _dbContext.SaveChanges();
    }
}
