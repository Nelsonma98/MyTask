using ApiTask.Context;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using ApiTask.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

string conectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(conectionString));

builder.Services.AddScoped<ITaskRepository, TaskRepository>();

//Add Swagger service
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TaskAPI",
        Version = "v1",
        Description = "A simple API for managing tasks"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskAPI V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();


app.MapControllers();

app.Run();
