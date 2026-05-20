using Microsoft.Extensions.DependencyInjection;

namespace CalorieTracker.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}
