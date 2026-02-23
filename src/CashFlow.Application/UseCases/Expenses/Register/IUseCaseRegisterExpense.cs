using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register;

public interface IUseCaseRegisterExpense
{
    public Task<ResponseRegisteredExpenseJson> Execute(RequestExpenseJson request);
}
