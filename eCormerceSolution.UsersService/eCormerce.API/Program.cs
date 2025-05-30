using eCommerce.Infrastructure;
using eCommerce.Core;
using eCormerce.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// add Infrastructure and Core services
builder.Services.AddInfrastructure();
builder.Services.AddCore();
// add controllers to the services
builder.Services.AddControllers();

var app = builder.Build();

// use customised exception middleware
app.UseExceptionHandlingMiddleware();

// Routing
app.UseRouting();

// Auth
app.UseAuthentication();
app.UseAuthorization();

// Controller routes
app.MapControllers();

app.Run();
