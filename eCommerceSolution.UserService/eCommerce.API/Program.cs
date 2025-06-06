using UserService.eCommerce.Infrastructure;
using UserService.eCommerce.Core;
using UserService.eCommerce.API.Middlewares;
using System.Text.Json.Serialization;
using UserService.eCommerce.Core.Mappers;

var builder = WebApplication.CreateBuilder(args);

// add Infrastructure services
builder.Services.AddInfrastructure();
// add Core services
builder.Services.AddCore();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

//builder.Services.AddAuthentication(); // ?
//builder.Services.AddAuthorization(); // ?

builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);

var app = builder.Build();

app.UseExceptionHandlingMiddleware();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
