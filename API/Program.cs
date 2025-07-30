using Abstracciones.BC;
using Abstracciones.BW;
using Abstracciones.DA;
using BC;
using BW;
using DA;
using DA.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUsuarioBW, UsuarioBW>();
builder.Services.AddScoped<IUsuarioDA, UsuarioDA>();
builder.Services.AddScoped<IAutenticacionBW, AutenticacionBW>();
builder.Services.AddScoped<IAutenticacionBC, AutenticacionBC>();

builder.Services.AddScoped<IRepositorioDapper, RepositorioDapper>();

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
