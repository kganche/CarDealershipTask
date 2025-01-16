using CarDealership.Api.DiTest;
using CarDealership.Api.Services;
using CarDealership.Data;
using CarDealership.Services.Store;
using CarDealership.Services.Store.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CarDealershipDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddScoped<IStoreService, StoreService>();

var services = new CarDealership.DI.ServiceCollection();

services.AddTransient<ITransientService, TransientService>();  
services.AddScoped<IScopedService, ScopedService>();    
services.AddSingleton<ISingletonService, SingletonService>();

var provider = services.BuildServiceProvider();

LifetimeTest.RunTests(provider);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
