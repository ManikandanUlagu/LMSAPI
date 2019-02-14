using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace cba.LoanManagement.Core.Api.Middleware
{
    public class SwaggerMiddleware : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<IParameter>();

            operation.Parameters.Add(new NonBodyParameter
            {
                Name = "RequestContext",
                In = "header",
                Type = "string",
                Required = false // set to false if this is optional
            });
        }
    }
}
