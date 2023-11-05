using Azure.Core;
using BookApp.DataService.Data;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = @"Server=localhost;
            Database=master;
            Trusted_Connection=True;
            TrustServerCertificate=True;";

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(config =>
        {
            config.WithOrigins(builder.Configuration["AllowedOrigins"] ?? string.Empty);
            config.AllowAnyHeader();
            config.AllowAnyMethod();
        });

        options.AddPolicy("AnyOrigin", config =>
        {
            config.AllowAnyHeader();
            config.AllowAnyOrigin();
            config.AllowAnyMethod();
        });
    }
);

var app = builder.Build();

if (app.Configuration.GetValue<bool>("UseDeveloperExceptionPage"))
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("api/error");
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapGet("api/error", [ResponseCache(NoStore = true)] () =>
    Results.Problem()).RequireCors("AnyOrigin");

app.MapControllers();

app.Run();
