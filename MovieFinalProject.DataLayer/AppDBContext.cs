using Microsoft.EntityFrameworkCore;
using MovieFinalProject.DataLayer.Models;

namespace MovieFinalProject.DataLayer
{
    public class AppDBContext : DbContext
    {
        public DbSet<TestModel> TestModels { get; set; }

        public AppDBContext()
        {

        }
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}
