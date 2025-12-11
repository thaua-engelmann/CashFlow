using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.Repositories;

internal class ExpensesDeleteOnlyRepository : IExpensesDeleteOnlyRepository
{
    private readonly CashFlowDbContext _dbContext;
    public ExpensesDeleteOnlyRepository(CashFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> Delete(long id)
    {
        var expenseDb = await _dbContext.Expenses.FirstOrDefaultAsync(e => e.Id == id);

        if (expenseDb is null)
        {
            return false;
        }

        _dbContext.Expenses.Remove(expenseDb);
        return true;
    }

}