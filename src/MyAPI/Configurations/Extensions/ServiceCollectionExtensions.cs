using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MyAPI.Business.Interfaces;
using MyAPI.Business.Interfaces.Repositories;
using MyAPI.Business.Interfaces.Services;
using MyAPI.Business.Notificacoes;
using MyAPI.Business.Services;
using MyAPI.Configurations.Filters;
using MyAPI.Configurations.Options;
using MyAPI.Data.Contexts;
using MyAPI.Data.Repositories;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MyAPI.Configurations.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMyDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }

        public static IServiceCollection AddMyApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            return services;
        }

        public static IServiceCollection AddMySwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(options => options.OperationFilter<SwaggerDefaultValues>());

            return services;
        }

        public static IServiceCollection AddMyDependencies(this IServiceCollection services)
        {
            services.AddScoped<MyDbContext>();

            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddScoped<IProdutoService, ProdutoService>();

            services.AddScoped<INotificador, Notificador>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}