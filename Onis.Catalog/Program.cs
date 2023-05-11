using Microsoft.EntityFrameworkCore;
using Onis.Domain.Contracts;
using Onis.Infrastructure.DB;
using Onis.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Beautify this...
builder.Services.AddDbContext<CatalogDBContext>(dbContextOptions => dbContextOptions.UseSqlServer(builder.Configuration.GetConnectionString("CatalogConnection")));
builder.Services.AddTransient<IRepository, Repository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API NAME 1.0.0.0"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
