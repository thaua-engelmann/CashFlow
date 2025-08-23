using CashFlow.Application.UseCases.Expenses;
using CashFlow.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    public class ExpenseController : CashFlowBaseController
    {

        [HttpPost]
        public async Task<IActionResult> Register([FromServices] IUseCaseRegisterExpense useCase, [FromBody] RequestRegisterExpenseJson request)
        {
            var response = await useCase.Execute(request);
            return Created(string.Empty, response);
        }
    }
}
