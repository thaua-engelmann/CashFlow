using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses.GetAll;

public sealed class UseCaseGetAllExpenses : IUseCaseGetAllExpenses
{
    private readonly IExpensesRepository _repository;
    private readonly IMapper _mapper;

    public UseCaseGetAllExpenses(IExpensesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseGetAllExpenses> Execute() {
        var expensesDb = await _repository.GetAll();

        var response = new ResponseGetAllExpenses
        {
            Expenses = _mapper.Map<List<ResponseSummaryExpense>>(expensesDb)
        };

        return response;
    }
}