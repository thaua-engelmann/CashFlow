using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.Repositories;

internal class ExpensesReadOnlyRepository : IExpensesReadOnlyRepository
{
    private readonly CashFlowDbContext _dbContext;

    public ExpensesReadOnlyRepository(CashFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Expense>> GetAll() =>
    await _dbContext.Expenses.AsNoTracking().ToListAsync();

    public async Task<Expense?> GetById(long id) =>
        await _dbContext.Expenses.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

}