using AutoMapper;
using GameLibrary.Api.ExceptionHandler;
using GameLibrary.IoC;
using GlobalExceptionHandler.WebApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;

namespace GameLibrary.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Game API", Version = "v1" });
            });

            BootStrapper.ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseGlobalExceptionHandler(x =>
            {
                x.ContentType = "application/json";
                x.ResponseBody(s => JsonConvert.SerializeObject(new
                {
                    Message = "An error occurred whilst processing your request"
                }));
                x.Map<RecordNotFoundException>().ToStatusCode(StatusCodes.Status404NotFound);
            });

            app.Map("/error", x => x.Run(y => throw new Exception()));

            app.UseRouting();

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseStaticFiles();
            app.UseSwagger();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Game API V1");
                c.RoutePrefix = "docs";
            });
        }
    }
}