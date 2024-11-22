using Microsoft.EntityFrameworkCore;
using ST10291238_PROG6212_POE.Models;

namespace ST10291238_PROG6212_POE.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ClaimsTable> Claims { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
    }
}
