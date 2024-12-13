using prueba_integrity.Infraestructure;
using Microsoft.OpenApi.Models;
using prueba_integrity.Infraestructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfraestructureServices(builder.Configuration);
builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = General.NombreApi, Version = "v1" }); });

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("v1/swagger.json", General.NombreApi + "-" + General.TipoApi + " v1"); });
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.Run();