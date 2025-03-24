using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SmartSchool.WebAPI.data;

namespace SmartSchool.WebAPI
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
            services.AddDbContext<SmartContext>(
                context => context.UseSqlite(Configuration.GetConnectionString("Default")) // Conexão com appsetings.json
            );

            // services.AddSingleton<IRepository, Repository>();
            // services.AddTransient<IRepository, Repository>();
            services.AddScoped<IRepository, Repository>();  //O IRepository vai ser uma instância do Repository pelo Scoped, ou seja,
                                                            //  a cada vez que uma requisição for feita uma instância do repository vai ser criada

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());  // Vai procurar quem está herdando de profile, para fazer o mapeamento entre os DTOs e os dominios(models)

            services.AddControllers()
                    .AddNewtonsoftJson(
                        opt => opt.SerializerSettings.ReferenceLoopHandling =
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore);           // Para fazer a aplicação parar o looping  

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            })
            .AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;  //Se não for definido uma versão para controller, a versão padrão será a que está definida na linha de cima
                options.ReportApiVersions = true;
            })
            ;

            var apiProviderDescription = services.BuildServiceProvider()
                                                 .GetService<IApiVersionDescriptionProvider>();


            services.AddSwaggerGen(options =>
            {

                foreach (var description in apiProviderDescription.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(
                      description.GroupName,
                      new Microsoft.OpenApi.Models.OpenApiInfo()
                      {
                          Title = "SmartSchool API",
                          Version = description.ApiVersion.ToString(),
                          TermsOfService = new Uri("https://www.google.com/"),
                          Description = "Descrição da WebAPi do SmartSchool",
                          License = new Microsoft.OpenApi.Models.OpenApiLicense
                          {
                              Name = "SmartSchool License",
                              Url = new Uri("https://www.google.com/")
                          },
                          Contact = new Microsoft.OpenApi.Models.OpenApiContact
                          {
                              Name = "Gustavo Vieira",
                              Email = null,
                              Url = new Uri("https://www.youtube.com/")
                          }
                      }
                  );
                }


                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommensFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);   //Combinando o xml com a pasta que vai ser criada
                options.IncludeXmlComments(xmlCommensFullPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider apiProviderDescription)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                foreach (var description in apiProviderDescription.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
                    options.RoutePrefix = "swagger";
                
            });

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}