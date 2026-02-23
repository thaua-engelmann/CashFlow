using CommomTestUtilities.Requests;
using FluentAssertions;
using CashFlow.Exception;
using CashFlow.Application.UseCases.Expenses;

namespace Validators.Tests.Expenses.Register
{
    public class ValidatorRegisterExpenseTests
    {
        private readonly ValidatorExpense _validator = new();

        [Fact]
        public void Success()
        {
            // The three "A" in unit testing:

            // Arrange = Where we config everything necessary to execute the test. 
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
            var result = _validator.Validate(request);

            // Assert = Where the given value is indeed validated / compared and the result is defined. 
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void ErrorTitleEmpty()
        {
            var request = RequestRegisterExpenseBuilder.Build();

            request.Title = string.Empty;

            var result = _validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceErrorMessages.TITLE_REQUIRED));
        }
    }
}
