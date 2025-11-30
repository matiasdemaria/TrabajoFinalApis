using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GymBroAPI.API.Config.Swagger;

public class AuthOperationsFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var attributes = context.ApiDescription.CustomAttributes();
        var isAuthRequired = attributes.Any(attr => attr.GetType() == typeof(AuthorizeAttribute));
        var isAllowAnonymous = attributes.Any(attr => attr.GetType() == typeof(AllowAnonymousAttribute));

        if (!isAuthRequired || isAllowAnonymous) return;

        operation.Security = new List<OpenApiSecurityRequirement>
        {
            new()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Token" }
                    },
                    Array.Empty<string>()
                }
            }
        };
    }
}