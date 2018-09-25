using Microsoft.EntityFrameworkCore;

namespace MultyProjectPoc.Data
{
    public class S1Context : DbContext
    {
        public S1Context(DbContextOptions<S1Context> options)
            : base(options)
        {
        }
    }
}