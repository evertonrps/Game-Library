using System;
using System.Collections.Generic;
using System.Text;
using GameLibrary.Data.Context;
using GameLibrary.Data.Repository;
using GameLibrary.Data.UoW;
using GameLibrary.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GameLibrary.IoC
{
    public static class BootStrapper
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GameLibraryContext>(options =>
                options.UseSqlServer(configuration["DefaultConnection"]));

            services.AddScoped(typeof(IGameRepository), typeof(GameRepository));
            services.AddScoped(typeof(IProducerRepository), typeof(ProducerRepository));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        }
    }
}
