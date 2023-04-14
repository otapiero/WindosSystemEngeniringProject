using AppServer_Project.BuisnesEntities;
using Microsoft.EntityFrameworkCore;

namespace AppServer_Project;


    public class ServerContext : DbContext
    {
        public DbSet<GameServer> Servers { get; set; }

        // Constructor with DbContextOptions parameter for configuring the database connection
        public ServerContext(DbContextOptions<ServerContext> options) : base(options)
        {
        }

        // Additional configuration and customization for the database context
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity mappings, relationships, etc.
            // Example:
            // modelBuilder.Entity<Server>().HasKey(s => s.Id);
            // modelBuilder.Entity<Server>().Property(s => s.Name).IsRequired();
        }
    }

