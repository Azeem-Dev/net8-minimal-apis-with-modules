using MovieFinalProject.Extensions.Core;

//SERVICES REGISTERATION FLOW
var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterServices(builder.Configuration);

//HTTP PIPELINE AND APP RELEVANT REGISTERATION FLOW
var app = builder.Build();
app.RegisterHttpApplicationServices();
app.Run();
