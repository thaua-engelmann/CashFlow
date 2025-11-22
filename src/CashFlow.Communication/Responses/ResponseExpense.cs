using CashFlow.Communication.Enums;

namespace CashFlow.Communication.Responses;

public sealed class ResponseExpense
{
    public required long Id { get; set; }
    public required string Title { get; set; } = string.Empty;
    public required string? Description { get; set; } = string.Empty;
    public required DateTime Date { get; set; }
    public required decimal Amount { get; set; }
    public required PaymentType PaymentType { get; set; }
}