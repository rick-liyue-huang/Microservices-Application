using UserService.eCommerce.Infrastructure;
using UserService.eCommerce.Core;

var builder = WebApplication.CreateBuilder(args);

// add Infrastructure services
builder.Services.AddInfrastructure();
// add Core services
builder.Services.AddCore();

builder.Services.AddControllers();

//builder.Services.AddAuthentication(); // ?
//builder.Services.AddAuthorization(); // ?

var app = builder.Build();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
