using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using Microsoft.AspNetCore.Builder;
 using Microsoft.AspNetCore.Hosting;
 using Microsoft.AspNetCore.HttpsPolicy;
 using Microsoft.AspNetCore.Mvc;
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
         }
 
         // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
         public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
         {
             if (env.IsDevelopment())
             {
                 app.UseDeveloperExceptionPage();
             }
 
             // app.UseHttpsRedirection();
 
             app.UseRouting();
 
             // app.UseAuthorization();
 
             app.UseEndpoints(endpoints =>
             {
                 endpoints.MapControllers();
             });
         }
     }
 }