using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameLibrary.Data.Context;
using GameLibrary.Domain.Interfaces;
using GameLibrary.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoMapper;
using System.Reflection;
using Swashbuckle.AspNetCore.Swagger;
using GameLibrary.Api.Middleware;
using GlobalExceptionHandler.WebApi;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using GameLibrary.Api.ExceptionHandler;

namespace GameLibrary.Api
{
    public class Startup
    {
        /*
         * Configuração IIS
         * https://docs.microsoft.com/pt-br/aspnet/core/host-and-deploy/iis/development-time-iis-support?view=aspnetcore-2.1
         * 
         * Tratamento de erros
         * https://github.com/JosephWoodward/GlobalExceptionHandlerDotNet
         * 
         */
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddOptions();

            services.AddAutoMapper();

      //      services.AddGlobalExceptionHandlerMiddleware();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Game API", Version = "v1" });
            });

            BootStrapper.ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseExceptionHandler(); You no longer need this.
            app.UseGlobalExceptionHandler(x => {
                x.ContentType = "application/json";
                x.ResponseBody(s => JsonConvert.SerializeObject(new
                {
                    Message = "An error occurred whilst processing your request"
                }));
                x.Map<RecordNotFoundException>().ToStatusCode(StatusCodes.Status404NotFound);
            });

            app.Map("/error", x => x.Run(y => throw new Exception()));

            //app.UseGlobalExceptionHandlerMiddleware();

            //app.Use(async (context, next) =>
            //{
            //    await next.Invoke();

            //    var unitOfWork = (IUnitOfWork)context.RequestServices.GetService(typeof(IUnitOfWork));
            //    await unitOfWork.Commit();
            //});
            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Game API V1");
                c.RoutePrefix = "docs";               
            });
            app.UseMvc();
        }
    }
}
