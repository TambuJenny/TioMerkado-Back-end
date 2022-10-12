using AplicationCore.Helpers;
using Infrastruture.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(
    options =>
        options.AddDefaultPolicy(builder =>
        {
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        })
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration["MyConnection"];
var secret = builder.Configuration["Secret"];
builder.Services.AddDbContext<DataBaseContext>(
    opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

ServicesHelper.RegisterBusinesses(services);
ServiceAuthentication.RegisterAuthentication(services, secret);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
