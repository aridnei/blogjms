using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using JmBlog.Data;
using JmBlog.Data.Contracts;
using JmBlog.Interfaces;
using JmBlog.Services;
using JmBlog.Setup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace JmBlog
{
    [ExcludeFromCodeCoverage]
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

            services.AddDbContext<BlogContext>(opt =>
                opt.UseInMemoryDatabase("DemoMemory")
            );
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddTransient<IPostService, PostService>();

            SetupSwagger(services);
            SetupCorsPolicy(services);
        }

        private static void SetupSwagger(IServiceCollection services)
        {
            services.ConfigureSwaggerGen(x =>
            {
                x.IncludeXmlComments("JmBlog.xml");
            });

            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.CustomSchemaIds(x => x.FullName);
                options.SwaggerDoc("v1", new Info
                {
                    Title = "JMS Blog",
                    Version = "v1",
                    Description = "Camada API de serviços do JMS Blog",
                    TermsOfService = "Termos do serviço",
                    Contact = new Contact()
                    {
                        Name = "Team JMS Blog"
                    }
                });

            });
        }

        private static void SetupCorsPolicy(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("CorsPolicy",
                                            builder => builder.AllowAnyHeader()
                                            .AllowAnyOrigin()
                                            .AllowAnyMethod()
                                            .AllowCredentials()
                        ));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Task.Run(() => 
            app.InitDB(Configuration)).Wait();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger()
              .UseSwaggerUI(c =>
              {
                  c.SwaggerEndpoint("v1/swagger.json", "API V1");
              });

            // Adicionando CORS
            app.UseCors("CorsPolicy");

            // app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
