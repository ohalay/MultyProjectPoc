using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MultyProjectPoc.Data
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, Project project, string connection)
        {
            var actionOptionsBuilder = new Action<DbContextOptionsBuilder>(dbContextBuilder => {
                dbContextBuilder.UseSqlServer(
                    connection,
                    builder => builder.EnableRetryOnFailure()
                );
            });

            services.AddDbContext<AppContext>(actionOptionsBuilder);

            switch(project)
            {
                case Project.STO: return services.AddDbContext<STOContext>(actionOptionsBuilder);
                case Project.S1: return services.AddDbContext<S1Context>(actionOptionsBuilder);
                default:
                    // Log Error
                    throw new NotSupportedException(); 
            }
           
        }
    }
}