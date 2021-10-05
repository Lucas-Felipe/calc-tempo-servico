using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MPRN.CalculadoraAposentadoria.Dominio.Entidades;
using MPRN.CalculadoraAposentadoria.Dominio.Validacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MPRN.CalculadoraAposentadoria.WebApi
{
    public class Startup
    {
        readonly string originstring = "_originstring";
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
                options.AddPolicy(originstring, builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
            
            services.AddControllers().AddJsonOptions(options=>{
                var enumConverter=new JsonStringEnumConverter();
                options.JsonSerializerOptions.Converters.Add(enumConverter);
            }).AddFluentValidation(fv =>
                { 
                    fv.RegisterValidatorsFromAssemblyContaining<CalculoTempoServicoValidacao>(); 
                    fv.DisableDataAnnotationsValidation = true; 
                }
            );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MPRN.CalculadoraAposentadoria.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MPRN.CalculadoraAposentadoria.WebApi v1"));
            }

           // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(originstring);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("http://localhost:4200","*","*");
            config.EnableCors(cors);
        }
    }
}
