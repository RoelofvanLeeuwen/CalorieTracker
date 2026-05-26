using CalorieTracker.Application.Interfaces;
using CalorieTracker.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CalorieTracker.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<INotificationService, NotificationService>();
        return services;
    }
}
