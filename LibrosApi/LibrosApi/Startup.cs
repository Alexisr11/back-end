using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrosApi.Filtros;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace LibrosApi
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
            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<AplicationDbContext>(opciones =>
            {
                opciones.UseSqlServer(Configuration.GetConnectionString("defaultConecction"));
            });


            services.AddCors(opciones =>
            {
                var fronendUrl = Configuration.GetValue<string>("front-end_url");
                opciones.AddDefaultPolicy(bulder =>
                {
                    bulder.WithOrigins(fronendUrl).AllowAnyMethod().AllowAnyHeader()
                    .WithExposedHeaders(new string[] {"cantidadTotalRegistros"} ) ;
                });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
            services.AddControllers(opctions => {
                opctions.Filters.Add(typeof(FiltroDeException));
            });
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

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
