using CashFlow.Communication.Responses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CashFlow.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {

        if (context.Exception is ExceptionCashFlow)
        {
            HandleException(context);
        }
        else
        {
            ThrowUnknownError(context);
        }
    }

    private void HandleException(ExceptionContext context)
    {

        if (context.Exception is ExceptionErrorOnValidation exceptionErrorOnValidation)
        {
            var errorResponse = new ResponseErrorJson(exceptionErrorOnValidation.Messages);

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(errorResponse);
        }
        else if (context.Exception is ExceptionNotFound exceptionNotFound)
        {
            var errorResponse = new ResponseErrorJson(exceptionNotFound.Message);

            context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            context.Result = new NotFoundObjectResult(errorResponse);
        }

    }

    private void ThrowUnknownError(ExceptionContext context)
    {

        var errorResponse = new ResponseErrorJson(ResourceErrorMessages.UNKNOWN_ERROR);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}
