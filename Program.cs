using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MultyProjectPoc.Data;

namespace MultyProjectPoc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args)
                .Build();

            // update DB from from cli
            using (IServiceScope scope = host.Services.GetRequiredService<IServiceScopeFactory>()
                                             .CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<Data.AppContext>()
                     .Database.Migrate();
                var projectContext = scope.ServiceProvider.GetRequiredService(typeof(STOContext)) as DbContext;
                projectContext?.Database?.Migrate();
            }
            
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)  {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        }
    }
}
