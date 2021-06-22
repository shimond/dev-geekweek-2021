using CatalogApi.Contracts;
using CatalogApi.Models.ConfigModels;
using CatalogApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi
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

            services.Configure<MockSetting>(Configuration.GetSection("mockSetting"));


            services.AddScoped<IMoviesService, MoviesServiceMock>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CatalogApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //user-secrets
            //Env variables
            var count = Configuration["devgeek:studentsInfo:count"];
            var path = Configuration["PATH"];
            var keyFromFile = Configuration["keyFromFile"];
            var geekFromFile = Configuration["geekFromFile"];
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CatalogApi v1"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}




//app.Use(async (context , next)=> {
//    await context.Response.WriteAsync("Code A 1  ");
//    await next();
//    await context.Response.WriteAsync("Code A 2  ");

//});

//// CORS

//app.Use(async (context, next) => {
//    await context.Response.WriteAsync("Code B 1  ");
//    await next();
//    await context.Response.WriteAsync("Code B 2  ");
//});

//app.UseStaticFiles();

//app.Run(async context => {
//    await context.Response.WriteAsync(" Hello ");
//});
