using Application.Features.Categories.Rules;
using Application.Features.Customers.Rules;
using Application.Features.Orders.Rules;
using Application.Features.Products.Rules;
using Application.Features.Products.Rules.ValidationRules;
using Core.Application.Pipelines;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssemblyContaining<CreateProductCommandValidator>();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddScoped<ProductBusinessRules>();
        services.AddScoped<CategoryBusinessRules>();
        services.AddScoped<OrderBusinessRules>();
        services.AddScoped<CustomerBusinessRules>();

        return services;
    }
}
