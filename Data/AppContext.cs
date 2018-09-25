using Microsoft.EntityFrameworkCore;

namespace MultyProjectPoc.Data
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
        }
    }
}