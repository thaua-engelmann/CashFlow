namespace CashFlow.Application.UseCases.Expenses.Delete;

public interface IUseCaseDeleteExpense
{
    Task Execute(long id);
}
