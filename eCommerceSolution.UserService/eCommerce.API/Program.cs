using UserService.eCommerce.Infrastructure;
using UserService.eCommerce.Core;
using UserService.eCommerce.API.Middlewares;
using System.Text.Json.Serialization;
using UserService.eCommerce.Core.Mappers;
using FluentValidation.AspNetCore;


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

// fluent validation
builder.Services.AddFluentValidationAutoValidation();


// Add API explorer services
builder.Services.AddEndpointsApiExplorer();

// add swagger generation services
builder.Services.AddSwaggerGen();

// add cors services
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyOrigin()
        .AllowAnyMethod();
    });
});


var app = builder.Build();

app.UseExceptionHandlingMiddleware();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger(); // add endpoint that can serve the swagger.json
app.UseSwaggerUI(); // Add swagger UI 
app.UseCors();

app.MapControllers();

app.Run();
