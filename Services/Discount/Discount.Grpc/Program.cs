using Discount.API.Interfaces;
using Discount.API.Repositories;
using Discount.Grpc.Extensions;
using Discount.Grpc.Grpc.Helpers;
using Discount.Grpc.Grpc.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddAutoMapper(typeof(DiscountProfile));
builder.Services.AddGrpc();

var app = builder.Build();

app.MigrateDatabase<Program>();

app.MapGrpcService<DiscountService>();

// Configure the HTTP request pipeline.
app.Run();