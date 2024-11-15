using MinimalApi.Infraestrutura.Db;
using MinimalApi.DTOs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbContexto>( options => {
  options.UseSqlServer(
    builder.Configuration.GetConnectionString( "ConnectionStrings" )
  );
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapPost("/login", (MinimalApi.DTOs.LoginDTO loginDTO) => {
  if (loginDTO.Email == "adm@teste.com" && loginDTO.Senha == "123456") 
    return Results.Ok("Login com Sucesso");
  else
    return Results.Unauthorized();
});

app.Run();


