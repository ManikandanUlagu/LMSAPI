using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace cba.LoanManagement.Core.Api.Middleware.Security
{
    public class SecurityHandler
    {
        private readonly RequestDelegate _next;
        public SecurityHandler(RequestDelegate next)
        {
            _next = next;

        }
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Headers.Keys.Contains("RequestContext"))
            {
                var base64EncodedText = Convert.FromBase64String(context.Request.Headers["RequestContext"]);

                if (Encoding.UTF8.GetString(base64EncodedText).Length <= 0)
                {
                    //Passes
                    context.Response.StatusCode = 401; //Unauthorized
                    return;
                }
            }
            else
            {
                context.Response.StatusCode = 401; //Unauthorized
                return;
            }

            await _next.Invoke(context);

        }
    }
}
