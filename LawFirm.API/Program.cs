//using LawFirm.Infrastructure.Extensions;
using Azure;
using LawFirm.API.Middlewares;
using LawFirm.Application;
using LawFirm.Application.Lawyers.Dtos;
using LawFirm.Domain.Repos;
using LawFirm.Infrastructure.Persistence;
using LawFirm.Infrastructure.Repos;
using LawFirm.Infrastructure.Seeders;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//keyed service
//builder.Services.AddSingleton<Interface1, Implementation1>("keyName1");
//builder.Services.AddSingleton<Interface1, Implementation2>("keyName2");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddScoped<ILawyerSeeder, LawyerSeeder>();  

builder.Services.AddScoped<ILawyersRepo, LawyersRepo>();
builder.Services.AddScoped<LawyersService>();

builder.Services.AddAutoMapper(typeof(LawyersProfile).Assembly);

var app = builder.Build();
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
// Seed the database
//using var scope = app.Services.CreateScope();
//var seeder = scope.ServiceProvider.GetRequiredService<ILawyerSeeder>();
//await seeder.Seed(); 

// Configure the HTTP request pipeline.
var logger = app.Logger;

//app.Use(async (context, next) =>
//{
//    logger.LogWarning("inline Request received");
//    context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
//    await next(context);
//    logger.LogWarning("inline Response sent");
//});

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


//var errorHandlingMw = new ErrorHandlingMw(new Logger<ErrorHandlingMw>(new LoggerFactory()));
//app.Use(errorHandlingMw.InvokeAsync);

app.UseMiddleware<ErrorHandlingMw>();

app.UseHttpsRedirection();

app.UseAuthorization();



app.MapControllers();

app.Run();
