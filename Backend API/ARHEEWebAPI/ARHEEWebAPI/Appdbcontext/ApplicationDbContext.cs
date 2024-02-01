using ARHEEWebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ARHEEWebAPI.Appdbcontext
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<UserDetails> userDetails { get; set; }
    }
}
