//https://github.com/Adenilsonlj/desafio_backend_stefanini

using Application.Cities.Services;
using Application.Customers.Models.Request;
using Application.Customers.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICustomerService, CustomerService>();
builder.Services.AddSingleton<ICityService, CityService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/customer/create", (CreateCustomerRequest request, ICustomerService service) =>
{
    return service.CreateCustomer(request);
});

app.Run();