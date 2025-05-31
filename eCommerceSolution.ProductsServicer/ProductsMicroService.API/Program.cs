using ProductsServicer.DataAccessLayer;
using ProductsServicer.BusinessLogicLayer;
using FluentValidation.AspNetCore;
using ProductsMicroService.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add DAL and BLL services to the container.
builder.Services.AddDataAccessLayer();
builder.Services.AddBusinessLogicLayer();

builder.Services.AddControllers();

// FluentValidations
builder.Services.AddFluentValidationAutoValidation();



var app = builder.Build();

app.UseExceptionHandlingMiddleware();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
