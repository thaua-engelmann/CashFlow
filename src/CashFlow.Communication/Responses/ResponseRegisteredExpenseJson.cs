namespace CashFlow.Communication.Responses;

public class ResponseRegisteredExpenseJson
{
    public long Id { get; }

    public ResponseRegisteredExpenseJson(long id)
    {
        Id = id;
    }
}
