using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace MyAPI.Configurations.Filters
{
    public class SwaggerDefaultValues : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation is null || operation.Parameters is null) return;

            foreach (var parameter in operation.Parameters)
            {
                var description = context.ApiDescription
                                         .ParameterDescriptions
                                         .First(p => p.Name == parameter.Name);

                operation.Deprecated = OpenApiOperation.DeprecatedDefault;

                parameter.Description ??= description.ModelMetadata?.Description;

                var routeInfo = description.RouteInfo;

                if (routeInfo is null) continue;

                if ((parameter.In is not ParameterLocation.Path) && (parameter.Schema.Default is null))
                    parameter.Schema.Default = new OpenApiString(routeInfo.DefaultValue.ToString());

                parameter.Required |= !routeInfo.IsOptional;
            }
        }
    }
}