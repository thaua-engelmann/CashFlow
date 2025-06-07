namespace CashFlow.Exception.ExceptionBase
{
    public class ExceptionErrorOnValidation : SystemException
    {
        public List<string> Messages { get; set; }

        public ExceptionErrorOnValidation(List<string> messages)
        {
            Messages = messages;
        }

    }
}
