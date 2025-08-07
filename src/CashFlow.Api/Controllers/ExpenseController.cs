using CashFlow.Application.UseCases.Expenses;
using CashFlow.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    public class ExpenseController : CashFlowBaseController
    {

        [HttpPost]
        public IActionResult Register([FromServices] IUseCaseRegisterExpense useCase, [FromBody] RequestRegisterExpenseJson request)
        {
            useCase.Execute(request);
            return Created();
        }
    }
}
