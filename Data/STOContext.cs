using Microsoft.EntityFrameworkCore;

namespace MultyProjectPoc.Data
{
    public class STOContext : DbContext
    {
        public STOContext(DbContextOptions<STOContext> options)
            : base(options)
        {
        }
    }
}