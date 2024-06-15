using Microsoft.EntityFrameworkCore;
using WebApplicationCQRS.Models;

namespace WebApplicationCQRS.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public virtual DbSet<Player> Players { get; set; }
    }
}
