using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.Repositories;
internal class ExpensesUpdateOnlyRepository(CashFlowDbContext dbContext) : IExpensesUpdateOnlyRepository
{
    public async Task<Expense?> GetById(long id)
        => await dbContext.Expenses.FirstOrDefaultAsync(e => e.Id == id); 
}
