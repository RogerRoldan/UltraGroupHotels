using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using MediatR;
using UltraGroupHotels.Application.Hotels.Common.Behaviors;

namespace UltraGroupHotels.Application.Implementations;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config => {
            config.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>();
        });

        services.AddScoped(
            typeof(IPipelineBehavior<,>), 
            typeof(ValidationBehavior<,>)
        );

        services.AddValidatorsFromAssemblyContaining<ApplicationAssemblyReference>();

        return services;
    }
}
