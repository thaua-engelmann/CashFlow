using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expense
{
    internal class ValidatorRegisterExpense : AbstractValidator<RequestRegisterExpenseJson>
    {
        public ValidatorRegisterExpense()
        {

            RuleFor(expense => expense.Title).NotEmpty().WithMessage("Title is required.");
            RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Date must not be in the future.");
            RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage("Amount must be greater than 0");
            RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage("PaymentType not valid.");
        }
    }
}
