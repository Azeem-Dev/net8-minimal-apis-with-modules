using MovieFinalProject.DataLayer.GenericRepository;
using MovieFinalProject.DataLayer.Models;
using MovieFinalProject.Shared.DbOptions;
using Microsoft.AspNetCore.Http;

namespace MovieFinalProject.EndpointHandlers.Product
{
    public static class ProductHandler
    {
        public static async Task<IResult> HandleAddProduct(int id, IRepository<TestModel> repository)
        {
            try
            {
                var existingTests = await GetExistingTestsAsync(repository);
                await AddNewTestAsync(repository, id);
                return Results.Ok(existingTests); // Optionally return the existing tests
            }
            catch (Exception ex)
            {
                // Consider logging the exception here
                return Results.Problem(
                    title: "Error processing request",
                    detail: ex.Message,
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }
        }

        private static async Task<List<TestModel>> GetExistingTestsAsync(IRepository<TestModel> repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            return (await repository.GetAllAsync(new FindOptions
            {
                IsAsNoTracking = true
            }))?.ToList() ?? new List<TestModel>();
        }

        private static async Task AddNewTestAsync(IRepository<TestModel> repository, int id)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            var newTest = CreateTestModel(id);
            await repository.AddAsync(newTest);
        }

        private static TestModel CreateTestModel(int id)
        {
            return new TestModel
            {
                Name = $"TEST BY AZEEM ID={id}"
            };
        }
    }
}