using GameLibrary.Data.Extensions;
using GameLibrary.Data.Mappings;
using GameLibrary.Domain.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GameLibrary.Data.Context
{
    public class GameLibraryContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<PlatformType> PlatformTypes { get; set; }
        public DbSet<GamePlatform> GamePlatforms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new GameMapping());
            modelBuilder.AddConfiguration(new DeveloperMapping());
            modelBuilder.AddConfiguration(new PlatformMapping());
            modelBuilder.AddConfiguration(new PlatformTypeMapping());
            modelBuilder.AddConfiguration(new GamePlatformMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
