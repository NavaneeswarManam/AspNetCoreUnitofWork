using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using UnitofWork.Environment;
using UnitofWork.Repositories;
using UnitofWork.Repositories.Infrastructure;
using UnitofWork.Repositories.Interface;

namespace UnitofWork
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
            var provider = services.BuildServiceProvider();
            var config = provider.GetRequiredService<IConfiguration>();
            var environmentConfig = new EnvironmentConfig(config);

            services.AddSingleton<IEnvironmentConfig, EnvironmentConfig>(p => environmentConfig);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddTransient<Func<string, IDbConnectionFactory>>(serviceProvider => key =>
            {
                var conn = environmentConfig.IndiaConnectionString;
                switch (key)
                {
                    case "denmark":
                        conn = environmentConfig.DenmarkString;
                        break;
                    case "uk":
                        conn = environmentConfig.UKString;
                        break;
                }
                return new DbConnectionFactory(conn);
            });


            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
