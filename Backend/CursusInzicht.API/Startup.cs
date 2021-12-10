using CursusInzicht.API.Services;
using CursusInzicht.API.Services.Interfaces;
using CursusInzicht.DataAcces;
using CursusInzicht.DataAcces.Repositories;
using CursusInzicht.Domain.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursusInzicht.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();
            services.AddDbContext<CursusInzichtContext>();
            services.AddScoped<ICursusRepository, CursusRepository>();
            services.AddScoped<ICursusInstantieRepository, CursusInstantieRepository>();
            services.AddScoped<IFileValidatorService, FileValidatorService>();
            services.AddScoped<ICursusExtractorService, CursusExtractorService>();
            services.AddScoped<ICursusInsertService, CursusInsertService>();
            services.AddScoped<IWeekNumberService, WeekNumberService>();

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
                builder.AllowAnyOrigin());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
