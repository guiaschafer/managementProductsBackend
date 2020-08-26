using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ManagementProducts.Service.Interface.Dtos;
using ManagementProducts.Service.Interface.Mappers;
using ManagementProducts.Service.Interface.Repositories;
using ManagementProducts.Service.Interface.Updaters;
using ManagementProducts.Service.Repositories;
using ManagementProducts.Service.Updaters;
using ManagementProducts.WebApi;
using ManagementProduts.DAL.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApi
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:3000/").AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                                  });
            });
            services.AddControllers();

            services.AddDbContext<DatabaseContext>(o =>
             o.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")));


            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(c => c.AddProfile<AutoMapping>(), typeof(Startup));
            services.TryAddScoped<IProductRepository, ProductRepository>();
            services.TryAddScoped<IProductUpdater, ProductUpdater>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Management Products");
                c.RoutePrefix = string.Empty;
            });

        }


    }
}
