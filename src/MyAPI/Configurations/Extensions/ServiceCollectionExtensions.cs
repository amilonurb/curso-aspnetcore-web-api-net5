using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyAPI.Business.Interfaces;
using MyAPI.Business.Interfaces.Repositories;
using MyAPI.Business.Interfaces.Services;
using MyAPI.Business.Notificacoes;
using MyAPI.Business.Services;
using MyAPI.Data.Contexts;
using MyAPI.Data.Repositories;

namespace MyAPI.Configurations.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMyDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }

        public static IServiceCollection AddMyDependencies(this IServiceCollection services)
        {
            services.AddScoped<MyDbContext>();

            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddScoped<IProdutoService, ProdutoService>();

            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}