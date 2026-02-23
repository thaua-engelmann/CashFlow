using CashFlow.Exception.ExceptionBase;
using FluentValidation;

namespace CashFlow.Application.Common;

public abstract class UseCaseBase
{
    protected void Validate<T>(IValidator<T> validator, T request)
    {
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errors = result.Errors
                .Select(vf => vf.ErrorMessage)
                .ToList();

            throw new ExceptionErrorOnValidation(errors);
        }
    }
};
