using CashFlow.Application.UseCases.Expense;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    public class ExpenseController : CashFlowBaseController
    {

        [HttpPost]
        public IActionResult Register(RequestRegisterExpenseJson request)
        {
            try
            {
                var useCase = new UseCaseRegisterExpense();
                useCase.Execute(request);

                return Created();
            }
            catch (ExceptionErrorOnValidation ex) {

                var errorResponse = new ResponseErrorJson(ex.Messages);
                return BadRequest(errorResponse);    

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }

        }
    }
}
