using EFCoreTest.Domain;
using EFCoreTest.Repository.Database;
using EFCoreTest.Repository.Database.Repositories;
using EFCoreTest.Repository.Database.Repositories.Interfaces;
using EFCoreTest.WebApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(LoggerFactory.Create(builder => builder.AddConsole()));
//builder.Services.AddScoped<DbContext, MemoryContext>((sp) => new MemoryContext(sp.GetRequiredService<ILoggerFactory>(), true));
builder.Services.AddScoped<DbContext, MemoryContext>((sp) => new MemoryContext(sp.GetRequiredService<ILoggerFactory>(), true));
builder.Services.AddScoped<IUserRepository, UserRepository>();
    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// register a scoped service


app.MapGet("/users", (IUserRepository userRepository) =>
{
	return userRepository.ListAll();
});

app.MapGet("/addresses", (IUserRepository userRepository) =>
{
	return userRepository.ListAllAddresses();
});


app.MapPost("/users", async (UserDto user, IUserRepository userRepository) =>
{
//	var x = JsonSerializer.Deserialize<User>(@"{
//	""Name"": ""string"",
//	""Email"": ""string"",
//	""Password"": ""string"",
//	""Addresses"": [{
//		""street"": ""Rua 2"",
//		""district"": null,
//		""city"": ""Cidade 1"",
//		""state"": ""Estado 1"",
//		""zipCode"": ""A99 B999"",
//		""id"": 1
//	}]
//}");

	userRepository.Add(user);
    await userRepository.Commit();
	return Results.Ok();
});


//var summaries = new[]
//{
//	"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast")
//.WithOpenApi();

app.Run();

//internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}
