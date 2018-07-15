using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using blog_api_dotnet_core2.Interfaces;
using blog_api_dotnet_core2.Repositories;
using blog_api_dotnet_core2.Models;
using blog_api_dotnet_core2.Models.Context;

namespace blog_api_dotnet_core2
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }   

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Repositories
            services.AddScoped<IRepository<Category>, CategoryRepository>();

            // Sql Server DbContext
            string cnnStr = Configuration["Database:ConnectionString"];
            services.AddDbContext<BlogDbContext>(options => 
                options.UseLazyLoadingProxies()
                .UseSqlServer(cnnStr));

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(options => options.SwaggerDoc("v1", new Info() { Title="", Version="v1" }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();
        }
    }
}
