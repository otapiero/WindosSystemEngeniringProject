using AppServer_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace AppServer_Project.Data;


public class ServersContext : DbContext
{
    public DbSet<GameServer> Servers { get; set; } =null!;

   

 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AppServerProject;Integrated Security=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GameServer>()
            .HasKey(gs => new { gs.ServerName, gs.DateTime });
    }
}

