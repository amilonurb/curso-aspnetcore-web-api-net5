using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace MyAPI.Configurations.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseMySwagger(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });

            return app;
        }
    }
}