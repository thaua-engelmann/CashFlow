﻿using CashFlow.Application.UseCases.Expenses.GetAll;
using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    public class ExpenseController : CashFlowBaseController
    {

        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredExpenseJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromServices] IUseCaseRegisterExpense useCase, [FromBody] RequestRegisterExpenseJson request)
        {
            var response = await useCase.Execute(request);
            return Created(string.Empty, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] IUseCaseGetAllExpenses useCase)
        {
            var response = await useCase.Execute();
            return Ok(response);
        }
    }
}
