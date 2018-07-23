// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Samples.Functional.Helpers;
using Samples.Functional.Transfer;
using Samples.FunctionalWebApi.Controllers;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace Samples.FunctionalWebApi
{
    /// <summary>
    /// This class starts up the application.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Samples.WebApi"); });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddControllersAsServices();

            ConfigureFunctionalDependencyInjection(services, Configuration);
            RegisterSwagger(services);
        }

        /// <summary>
        /// A functional take on DI. https://andrewlock.net/controller-activation-and-dependency-injection-in-asp-net-core-mvc/
        /// </summary>
        private static void ConfigureFunctionalDependencyInjection(IServiceCollection services, IConfiguration configuration)
        {
            ConnectionString connString = configuration.GetSection("ConnectionString").Value;

            services.AddTransient(provider => new TransferController(
                provider.GetRequiredService<ILogger<TransferController>>(),
                connString.Execute<BookTransferDao>(),
                () => DateTime.Now));
        }

        /// <summary>
        /// Register swagger.
        /// </summary>
        private static void RegisterSwagger(IServiceCollection services)
            => services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Samples.FunctionalWebApi",
                    Description = "A sample web api using functional programming.",
                    TermsOfService = "None"
                });

                //Set the comments path for the swagger json and ui.
                string basePath = AppContext.BaseDirectory;
                string xmlPath = Path.Combine(basePath, "Samples.FunctionalWebApi.xml");
                c.IncludeXmlComments(xmlPath);
            });
    }
}