using Bogus;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;

namespace CommomTestUtilities.Requests
{
    public class RequestRegisterExpenseBuilder
    {

        public static RequestRegisterExpenseJson Build()
        {

            var faker = new Faker();

            return new RequestRegisterExpenseJson
            {
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                Date = faker.Date.Past(),
                Amount = faker.Random.Decimal(min: 1, max: 2000),
                PaymentType = faker.PickRandom<PaymentType>()
            };
        }

    }
}
