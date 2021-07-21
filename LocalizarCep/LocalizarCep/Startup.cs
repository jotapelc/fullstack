using System;
using System.Collections.Generic;
using LocalizarCep.Aplicacao.Aplicacao;
using LocalizarCep.Aplicacao.Contrato;
using LocalizarCep.Dominio.Contratos.Repositorios;
using LocalizarCep.Dominio.Contratos.Servicos;
using LocalizarCep.Dominio.Servicos;
using LocalizarCep.Repositorio.Repositorios;
using LocalizarCep.Servicos.API;
using LocalizarCep.Servicos.API.Contratos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace LocalizarCep
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
            #region Injeção dependência - Repositorio
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            #endregion

            #region Injeção dependência - Servicos
            services.AddTransient<IApiServico, ApiServico>();
            services.AddTransient<IUsuarioServico, UsuarioServico>();
            #endregion

            #region Injeção dependência - Aplicacao
            services.AddTransient<ICEPAplicacao, CEPAplicacao>();
            services.AddTransient<IUsuarioAplicacao, UsuarioAplicacao>();
            #endregion

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LocalizarCep", Version = "v1" });
            });

            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
            }));

            services.AddMvc();

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
            app.UseCors("ApiCorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}
