using Microsoft.EntityFrameworkCore;
using ProfileService.Models;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var server = configuration["DbServer"] ?? "localhost";
var port = configuration["DbPort"] ?? "1433";
var user = configuration["DbUser"] = "SA";
var pwd = configuration["DbPwd"] = "Letmein123";
var database = configuration["DB"] = "COMP2001_Examples";

builder.Services.AddDbContext<ProfileContext>(options => 
options.UseSqlServer($"Server={server}, {port};Initial Catalog={database};User ID={user};Password={pwd}"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
