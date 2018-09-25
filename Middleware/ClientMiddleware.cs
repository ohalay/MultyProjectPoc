using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace MultyProjectPoc.Middleware
{
    public class ClientMiddleware
    {
        private readonly RequestDelegate _next;

        public ClientMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Path.Value.StartsWith("/api/"))
            {
                AddClient(context);
            }
            await _next(context);
        }

        private void AddClient(HttpContext context)
        {
            context.Items.Add(Const.ProjectKey, GetIdentityCustomer(context.Request.Host));
        }
        
        private string GetIdentityCustomer(HostString host)
        {
            // get configuration from db
            return string.Equals(host.Host, "localhost", StringComparison.InvariantCultureIgnoreCase) 
                ? "secur"
                : host.Host;
        }
    }
}
