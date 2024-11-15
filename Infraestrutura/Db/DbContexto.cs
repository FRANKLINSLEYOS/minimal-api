using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MinimalApi.Dominio.Entidades;

namespace MinimalApi.Infraestrutura.Db;
public class DbContexto : DbContext
{
  private readonly IConfiguration _configuration;
  public DbContexto(IConfiguration configuration)
  {
    _configuration = configuration;
  }

  public DbSet<Administrador> Administradores { get; set;} =default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var stringConexao = _configuration.GetConnectionString("ConnectionStrings")?.ToString();
        if (!string.IsNullOrEmpty(stringConexao))
        {
          optionsBuilder
                .UseSqlServer(
                    stringConexao,
                    providerOptions => { providerOptions.EnableRetryOnFailure(); });
        }
    } 
}