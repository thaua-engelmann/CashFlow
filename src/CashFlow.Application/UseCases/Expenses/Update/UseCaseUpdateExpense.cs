using AutoMapper;
using CashFlow.Application.Common;
using CashFlow.Communication.Requests;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionBase;
using FluentValidation;
namespace CashFlow.Application.UseCases.Expenses.Update;
internal class UseCaseUpdateExpense(
    IValidator<RequestExpenseJson> validator,
    IExpensesUpdateOnlyRepository repository,
    IMapper mapper,
    IUnitOfWork unitOfWork) : UseCaseBase, IUseCaseUpdateExpense
{
    public async Task Execute(long id, RequestExpenseJson request)
    {
        Validate(validator, request);

        var expenseDb = await repository.GetById(id);

        if (expenseDb == null)
            throw new ExceptionNotFound(ResourceErrorMessages.EXPENSE_NOT_FOUND);

        mapper.Map(request, expenseDb);
        await unitOfWork.Commit();
    }
}
