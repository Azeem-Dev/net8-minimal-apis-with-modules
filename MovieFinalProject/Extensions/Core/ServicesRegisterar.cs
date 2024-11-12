using Microsoft.EntityFrameworkCore;
using MovieFinalProject.DataLayer;
using MovieFinalProject.DataLayer.GenericRepository;

namespace MovieFinalProject.Extensions.Core
{
    public static class ServicesRegisterar
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Requires Microsoft.AspNetCore.Authentication.JwtBearer
            //services.AddAuthentication().AddJwtBearer();

            services.RegisterDbAccessServices(configuration);
        }
    }
}
