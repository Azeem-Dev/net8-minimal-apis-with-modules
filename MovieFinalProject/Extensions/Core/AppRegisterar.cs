using MovieFinalProject.Extensions.Routing;

namespace MovieFinalProject.Extensions.Core
{
    public static class AppRegisterar
    {
        public static void RegisterHttpApplicationServices(this WebApplication app)
        {

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();


            app.RegisterModules();
        }
    }
}
