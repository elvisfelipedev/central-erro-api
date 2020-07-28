using CentralErros.Business.Interfaces;
using CentralErros.Business.Interfaces.Repositories;
using CentralErros.Business.Interfaces.Services;
using CentralErros.Business.Notifications;
using CentralErros.Business.Services;
using CentralErros.Data.Context;
using CentralErros.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CentralErros.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<Contexto>();
            services.AddScoped<ILogRepository, LogRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<ILogService, LogService>();

            return services;
        }
    }
}
