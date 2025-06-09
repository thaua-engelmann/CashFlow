using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Expense
{
    public class UseCaseRegisterExpense
    {

        public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
        {
            Validate(request);

            return new ResponseRegisteredExpenseJson();
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
