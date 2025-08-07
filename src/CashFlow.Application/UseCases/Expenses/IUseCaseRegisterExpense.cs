using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses
{
    public interface IUseCaseRegisterExpense
    {
        public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request);
    }
}
