using CashFlow.Communication.Requests;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Expense
{
    public class UseCaseRegisterExpense
    {

        public void Execute(RequestRegisterExpenseJson request)
        {
            Validate(request);
        }

        private void Validate(RequestRegisterExpenseJson request)
        {

            var validator = new ValidatorRegisterExpense();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(validationFailure => validationFailure.ErrorMessage).ToList();
                throw new ExceptionErrorOnValidation(errorMessages);
            }
        }

    }
}
