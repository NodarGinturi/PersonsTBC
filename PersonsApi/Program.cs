using Microsoft.OpenApi.Models;
using Persons.Application;
using Persons.Application.Features.Persons.Commands.Create;
using Persons.Persistence.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "Person API" });
});

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

// Enable middleware for Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Person API V1");
    });

}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
