using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Entities;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Expenses
{
    public class UseCaseRegisterExpense : IUseCaseRegisterExpense
    {

        private readonly IExpensesRepository _repository;

        public UseCaseRegisterExpense(IExpensesRepository repository)
        {
            _repository = repository;
        }

        public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
        {
            Validate(request);

            var entity = new Expense
            {
                Title = request.Title,
                Amount = request.Amount,
                Date = request.Date,
                PaymentType = request.PaymentType,
                Description = request.Description,
            };

            _repository.Add(entity);

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
