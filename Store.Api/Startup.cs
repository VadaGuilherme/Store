using System.ComponentModel;
using System.IO;
using System;
using Elmah.Io;
using Elmah.Io.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Store.Domain.StoreContext.Handlers;
using Store.Domain.StoreContext.Repositories;
using Store.Domain.StoreContext.Services;
using Store.Infra.StoreContext.DataContexts;
using Store.Infra.StoreContext.Repositories;
using Store.Infra.StoreContext.Services;
using Store.Shared;

namespace Store.Api
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc();

            services.AddResponseCompression();

            services.AddScoped<StoreDataContext, StoreDataContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailServices>();
            services.AddTransient<CustomerHandler, CustomerHandler>();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "Store",
                    Version = "v1"
                });
            });

            services.AddElmahIo(o =>
{
                o.ApiKey = "ed497fc444eb422fb374e481d05264c4";
                o.LogId = new Guid("a91e9f2a-f4e4-474f-8438-14501b71b6eb");
            });

            //TODO: Configurar ConnectionString
            Settings.ConnectionString = "";


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseMvc();

            app.UseResponseCompression();

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseElmahIo();
        }
    }
}
