using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace GameOfChance.API.Filters
{
    public class LoginFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = SetDefaultParametersFor(context.Type);
        }

        private IOpenApiAny SetDefaultParametersFor(MemberInfo type) // parameter changed from Type to MemberInfo
        {
            // setting the default values for request model.
            return type.Name switch
            {
                "LoginRequest" => new OpenApiObject
                {
                    ["Username"] = new OpenApiString("demo"),
                    ["Password"] = new OpenApiString("P@$$w0rd")
                },
                _ => null
            };
        }
    }
}
