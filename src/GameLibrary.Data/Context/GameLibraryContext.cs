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
        public DbSet<Producer> Producers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new GameMapping());
            modelBuilder.AddConfiguration(new ProducerMapping());

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
