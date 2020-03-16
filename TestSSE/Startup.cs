using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using TestSSE.Contexts;
//using TestSSE.Services;

namespace TestSSE
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            ConfigureSwagger(services);


            //services.AddDbContext<ProductInfoContext>(options =>
            //options.UseNpgsql(Configuration.GetConnectionString("ProductInfoContext")));

            var connectionString = @"Data Source=Products.db";
            services.AddDbContext<ProductInfoContext>(o =>
            {
                o.UseSqlite(connectionString);
            });

           // services.AddScoped<IProductInfoRepository, ProductInfoRepository>();

            //var connectionString = @"Server=(localdb)\mssqllocaldb;Database=ProductInfoDb;Trusted_Connection=True;";
           //  services.AddDbContext<ProductInfoContext>(o =>
            // {
           //      o.UseSqlServer(connectionString);
           //  });
        }

        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseStatusCodePages();
            app.UseMvc();
           
        }
    }
}
