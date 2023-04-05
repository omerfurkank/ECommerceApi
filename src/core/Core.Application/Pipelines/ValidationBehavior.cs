using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Pipelines;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken
                                 )
    {
        ValidationContext<object> context = new(request);
        List<ValidationFailure> failures = _validators
                                           .Select(validator => validator.Validate(context))
                                           .SelectMany(result => result.Errors)
                                           .Where(failure => failure != null)
                                           .ToList();
        if (failures.Count != 0) throw new Exception("validation error");
        return next();
    }

}
