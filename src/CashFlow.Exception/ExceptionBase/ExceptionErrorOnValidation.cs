namespace CashFlow.Exception.ExceptionBase
{
    public class ExceptionErrorOnValidation : ExceptionCashFlow
    {
        public List<string> Messages { get; set; }

        public ExceptionErrorOnValidation(List<string> messages)
        {
            Messages = messages;
        }

    }
}
