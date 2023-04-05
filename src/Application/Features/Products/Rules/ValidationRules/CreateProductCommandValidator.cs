using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Rules.ValidationRules;

public class CreateProductCommandValidator : AbstractValidator<Product>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p=>p.Name).NotEmpty();
    }
}
