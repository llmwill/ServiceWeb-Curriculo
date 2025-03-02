using Curriculos.Models;
using Microsoft.EntityFrameworkCore;

namespace Curriculos.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)  : base(options) { }

        public DbSet<Curriculum> Curriculums { get; set; }
    }
}
