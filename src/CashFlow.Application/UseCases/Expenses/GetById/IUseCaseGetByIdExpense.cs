using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.GetById;

public interface IUseCaseGetByIdExpense {
    Task<ResponseExpense> Execute(long id);
}