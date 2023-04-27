using Company.Delivery.Api.AppStart;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDeliveryControllers();
builder.Services.AddDeliveryApi();

var app = builder.Build();

app.UseDeliveryApi();
app.MapControllers();

app.Run();