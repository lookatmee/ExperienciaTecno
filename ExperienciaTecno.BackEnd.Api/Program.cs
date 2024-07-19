using ExperienciaTecno.BackEnd.Api.Infraestructure.Extensions;
using ExperienciaTecno.BackEnd.Core.Common.Data.Impl;
using ExperienciaTecno.BackEnd.Core.Common.Data;
using ExperienciaTecno.BackEnd.Data.EF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = builder.Configuration;
builder.Services.AddDbContext<BackEndDbContext>(option =>
option.UseSqlServer(configuration.GetConnectionString("ExperienciaTecnoDBConexion")));

builder.Services.RegisterDependencies();

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork<BackEndDbContext>>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
