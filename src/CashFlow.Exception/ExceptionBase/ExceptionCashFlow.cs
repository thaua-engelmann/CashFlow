namespace CashFlow.Exception.ExceptionBase;

public abstract class ExceptionCashFlow : SystemException
{
    protected ExceptionCashFlow(string message) : base(message)
    {

    }
}

