using AutoMapper;
using CashFlow.Application.Common;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class UseCaseRegisterExpense(
    IExpensesWriteOnlyRepository repository,
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IValidator<RequestExpenseJson> validator) : UseCaseBase, IUseCaseRegisterExpense
{
    public async Task<ResponseRegisteredExpenseJson> Execute(RequestExpenseJson request)
    {
        Validate(validator, request);

        var entity = mapper.Map<Expense>(request);

        await repository.Add(entity);
        await unitOfWork.Commit();

        return mapper.Map<ResponseRegisteredExpenseJson>(entity);
    }
}
