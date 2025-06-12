using CashFlow.Application.UseCases.Expense;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Enums;
using CommomTestUtilities.Requests;

namespace Validators.Tests.Expenses.Register
{
    public class ValidatorRegisterExpenseTests
    {

        [Fact]
        public void Success()
        {
            // The three "A" in unit testing:

            // Arrange = Where we config everything necessary to execute the test. 
            var validator = new ValidatorRegisterExpense();
            var request = RequestRegisterExpenseBuilder.Build();

            //var request = new RequestRegisterExpenseJson
            //{
            //    Title = "Wireless headset",
            //    Description = "I bought these earbuds mainly for the gym",
            //    Date = DateTime.Now.AddDays(2),
            //    Amount = 110,
            //    PaymentType = PaymentType.Pix
            //};

            // Act = Where we execute the logic to be checked by the test.
            var result = validator.Validate(request);

            // Assert = Where the given value is indeed validated / compared and the result is defined. 
            Assert.True(result.IsValid);
        }

    }
}
