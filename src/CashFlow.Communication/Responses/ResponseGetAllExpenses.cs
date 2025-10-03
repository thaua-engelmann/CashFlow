namespace CashFlow.Communication.Responses;

public sealed class ResponseGetAllExpenses
{
    public List<ResponseSummaryExpense> Expenses { get; set; } = [];
}