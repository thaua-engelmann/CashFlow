using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Expenses.Delete;

public class UseCaseDeleteExpense : IUseCaseDeleteExpense
{
    private readonly IExpensesDeleteOnlyRepository _deleteRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UseCaseDeleteExpense(IExpensesDeleteOnlyRepository deleteRepository, IUnitOfWork unitOfWork)
    {
        _deleteRepository = deleteRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(long id)
    {
        var result = await _deleteRepository.Delete(id);

        if (!result)
        {
            throw new ExceptionNotFound(ResourceErrorMessages.EXPENSE_NOT_FOUND);
        }
    
        await _unitOfWork.Commit();
    }
}