using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Expenses.GetById;
public sealed class UseCaseGetByIdExpense : IUseCaseGetByIdExpense
{
    private readonly IExpensesRepository _repository;
    private readonly IMapper _mapper;

    public UseCaseGetByIdExpense(IExpensesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseExpense> Execute(long id)
    {
        var expenseDb = await _repository.GetById(id);

        if (expenseDb is null)
        {
            throw new ExceptionNotFound(ResourceErrorMessages.EXPENSE_NOT_FOUND);
        }

        var response = _mapper.Map<ResponseExpense>(expenseDb);

        return response;
    }
}