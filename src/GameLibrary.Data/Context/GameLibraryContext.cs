using GameLibrary.Data.Extensions;
using GameLibrary.Data.Mappings;
using GameLibrary.Domain.Entities.Games;
using GameLibrary.Domain.Entities.Usuario;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
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
        public DbSet<Usuario> Usuarios { get; set; }

        public GameLibraryContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new GameMapping());
            modelBuilder.AddConfiguration(new DeveloperMapping());
            modelBuilder.AddConfiguration(new PlatformMapping());
            modelBuilder.AddConfiguration(new PlatformTypeMapping());
            modelBuilder.AddConfiguration(new GamePlatformMapping());
            modelBuilder.AddConfiguration(new UsuarioMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // var config = new ConfigurationBuilder()
            //     .SetBasePath(Directory.GetCurrentDirectory())
            //     .AddJsonFile("appsettings.json")
            //     .Build();

            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlite(CreateInMemoryDatabase());
            //optionsBuilder.UseInMemoryDatabase();
            //optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("DataSource=file::memory:?cache=shared");

            connection.Open();

            return connection;
        }
    }
}