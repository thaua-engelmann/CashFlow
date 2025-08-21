using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Entities;
using CashFlow.Exception.ExceptionBase;
using CashFlow.Domain.Repositories;

namespace CashFlow.Application.UseCases.Expenses
{
    public class UseCaseRegisterExpense : IUseCaseRegisterExpense
    {

        private readonly IExpensesRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UseCaseRegisterExpense(IExpensesRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseRegisteredExpenseJson> Execute(RequestRegisterExpenseJson request)
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

            await _repository.Add(entity);
            await _unitOfWork.Commit();

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
