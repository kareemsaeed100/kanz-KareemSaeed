using KanzWay.Services;
namespace KanzWay.DependencyConfiguration;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IScreeningService, ScreeningService>();
        services.AddControllers().ConfigureApiBehaviorOptions(opt => opt.SuppressModelStateInvalidFilter = true);
    }
}
