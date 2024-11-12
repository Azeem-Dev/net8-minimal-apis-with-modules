using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieFinalProject.DataLayer.GenericRepository;

namespace MovieFinalProject.DataLayer
{
    public static class DbAccessRegisterar
    {
        public static void RegisterDbAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDBContext>(options =>
                options.UseSqlite(GetDbPath(configuration)));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        private static string GetDbPath(IConfiguration configuration)
        {
            var dbFileName = configuration.GetConnectionString("SqlLite");
            var solutionBasePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\"));
            var dbPath = Path.Combine(solutionBasePath, "MovieFinalProject.DataLayer", dbFileName);
            return $"Data Source={dbPath}";
        }
    }
}
