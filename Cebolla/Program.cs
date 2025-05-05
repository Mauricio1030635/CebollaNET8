

using Cebolla.Application.Interfaces;
using Cebolla.Application.MappingProfiles;
using Cebolla.Application.Services;
using Cebolla.Domain.Interfaces;
using Cebolla.Infrastructure.EF;
using Cebolla.Infrastructure.EF.Context;
using Cebolla.Infrastructure.EF.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



// Configuración EF Core
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// AutoMapper
builder.Services.AddAutoMapper(typeof(PersonaProfile));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


// Registrar servicios de aplicación
builder.Services.AddScoped<IPersonaService, PersonaService>();

// Usar una implementación: EF o Dapper
builder.Services.AddScoped<IPersonaRepository, PersonaRepositoryEf>();
// O si quieres usar Dapper:
// builder.Services.AddScoped<IPersonaRepository>(provider =>
//     new PersonaRepositoryDapper(builder.Configuration.GetConnectionString("DefaultConnection")!));

builder.Services.AddControllers();
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
