using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses
{
    public interface IUseCaseRegisterExpense
    {
        public Task<ResponseRegisteredExpenseJson> Execute(RequestRegisterExpenseJson request);
    }
}
