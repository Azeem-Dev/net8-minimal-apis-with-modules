using MovieFinalProject.Modules;

namespace MovieFinalProject.Extensions.Routing
{
    public static class ModulesRegisterar
    {
        public static void RegisterModules(this IEndpointRouteBuilder app)
        {
            app.AddProductEndpoints();
        }
    }
}
