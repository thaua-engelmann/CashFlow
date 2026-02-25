using CashFlow.Communication.Requests;

namespace CashFlow.Application.UseCases.Expenses.Update;
public interface IUseCaseUpdateExpense {
    Task Execute(long id, RequestExpenseJson request);
}
