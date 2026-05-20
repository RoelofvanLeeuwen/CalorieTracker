using CalorieTracker.Application.Interfaces;
using CalorieTracker.Infrastructure.Persistence;
using CalorieTracker.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CalorieTracker.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IProductRepository,          ProductRepository>();
        services.AddScoped<IConsumptionEntryRepository, ConsumptionEntryRepository>();
        services.AddScoped<IUserProfileRepository,      UserProfileRepository>();

        return services;
    }
}
