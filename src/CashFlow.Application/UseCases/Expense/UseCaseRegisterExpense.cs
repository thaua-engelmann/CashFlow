using CashFlow.Communication.Requests;

namespace CashFlow.Application.UseCases.Expense
{
    public class UseCaseRegisterExpense
    {

        public void Execute(RequestRegisterExpenseJson request)
        {
            IsRequestValid(request);
        }

        private bool IsRequestValid(RequestRegisterExpenseJson request)
        {
            var isTitleValid = string.IsNullOrWhiteSpace(request.Title);

            return true;
        }

    }
}
