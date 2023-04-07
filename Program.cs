using Exercicios_Semana08_WebAPI.Interface;
using Exercicios_Semana08_WebAPI.Models;
using Exercicios_Semana08_WebAPI.Services;

var builder = WebApplication.CreateBuilder();



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<IClienteServices, ClientesServices>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
