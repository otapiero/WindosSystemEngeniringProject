using AppServer_Project.BuisnesEntities;
using Microsoft.EntityFrameworkCore;

namespace AppServer_Project.Data;


public class ServerContext : DbContext
{
    public DbSet<GameServer> Servers { get; set; } =null!;

   

 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ContosoPizza-Part1;Integrated Security=True;");
    }
}

