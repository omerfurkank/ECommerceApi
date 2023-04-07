using Application.Features.Products.Commands;
using FluentValidation;

namespace Application.Features.Products.Rules.ValidationRules;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().MinimumLength(2);
    }
}
