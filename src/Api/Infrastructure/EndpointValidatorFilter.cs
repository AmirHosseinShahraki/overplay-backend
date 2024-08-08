using FluentValidation;
using FluentValidation.Results;
using ValidationException = Application.Common.Exceptions.ValidationException;

namespace Api.Infrastructure;

public class EndpointValidatorFilter<T>(IValidator<T> validator) : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        T inputData = context.GetArgument<T>(0);

        if (inputData is null)
            return await next.Invoke(context);

        ValidationResult? validationResult = await validator.ValidateAsync(inputData);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        return await next.Invoke(context);
    }
}

public static class ValidatorExtensions
{
    public static RouteHandlerBuilder Validator<T>(this RouteHandlerBuilder handlerBuilder)
        where T : class
    {
        handlerBuilder.AddEndpointFilter<EndpointValidatorFilter<T>>();
        return handlerBuilder;
    }
}