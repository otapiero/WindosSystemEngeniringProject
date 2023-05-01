using AppServer_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace AppServer_Project.Data;


public class ServerContext : DbContext
{
    public DbSet<GameServer> Servers { get; set; } =null!;

   

 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AppServer_Project.AvailebleGames;Trusted_Connection=True;MultipleActiveResultSets=true");
    }
}

