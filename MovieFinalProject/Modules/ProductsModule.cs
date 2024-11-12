using MovieFinalProject.EndpointHandlers.Product;

namespace MovieFinalProject.Modules
{
    public static class ProductsModule
    {
        public static void AddProductEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/products/{id}", ProductHandler.HandleAddProduct)
                .WithName("GetProductById")
                .WithOpenApi();
        }
    }
}
