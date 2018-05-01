// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedMember.Global
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Samples.ApplicationLayer;
using Samples.ApplicationLayer.Organizations;
using Samples.ApplicationLayer.Persons;
using Samples.InfrastructureLayer.DataContext;
using Samples.InfrastructureLayer.Organizations;
using Samples.InfrastructureLayer.Persons;
using Samples.WebApi.AppSettings;
using Samples.WebApi.Middleware;
using Samples.WebApi.Security;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace Samples.WebApi
{
    /// <summary>
    /// The startup of the application.
    /// </summary>
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            string appInsightsKey = _configuration["ApplicationInsights:InstrumentationKey"];
            loggerFactory.AddApplicationInsights(new ApplicationInsightsSettings
            {
                DeveloperMode = true,
                InstrumentationKey = appInsightsKey
            });

            app.UseErrorHandling(loggerFactory.CreateLogger(typeof(ErrorHandling)));

            app.UseAuthentication();

            app.UseMvcWithDefaultRoute();

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
            services.AddMvc();
            services.AddAutoMapper(mce => mce.AddProfile(new PersonMapping(DateTime.Now)));

            ConfigureCors(services);
            ConfigureEntityFramework(services);
            ConfigureSettings(services);
            ConfigureAuthentication(services);
            ConfigureDependencyInjection(services);
            RegisterSwagger(services);
        }

        /// <summary>
        /// Configure dependency injection.
        /// </summary>
        private static void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddTransient<IPersonInteractor, PersonInteractor>();
            services.AddTransient<IQueries<IPersonDto>, PersonQueries>();
            services.AddTransient<IQueries<IOrganizationDto>, OrganizationQueries>();
            services.AddTransient<IPersonCommands, PersonCommands>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
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
                    Title = "Samples.WebApi",
                    Description = "A sample web api.",
                    TermsOfService = "None"
                });

                //Set the comments path for the swagger json and ui.
                string basePath = AppContext.BaseDirectory;
                string xmlPath = Path.Combine(basePath, "Samples.WebApi.xml");
                c.IncludeXmlComments(xmlPath);
            });

        /// <summary>
        /// Configure authentication.
        /// </summary>
        private void ConfigureAuthentication(IServiceCollection services)
            => services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = !_environment.IsDevelopment();

                    // AD
                    options.Authority = $"{_configuration["Authentication:AzureAd:AADInstance"]}{_configuration["Authentication:AzureAd:TenantId"]}";
                    options.TokenValidationParameters.ValidateAudience = false;

                    // B2C
                    var b2CTokenValidator = new B2CSecurityTokenValidator(
                        _configuration["Authentication:B2C:TenantId"],
                        _configuration["Authentication:B2C:Policy"]);

                    options.SecurityTokenValidators.Add(b2CTokenValidator);
                    options.TokenValidationParameters.ValidIssuers = new[] { b2CTokenValidator.Issuer };
                });

        /// <summary>
        /// Configure CORS.
        /// </summary>
        private void ConfigureCors(IServiceCollection services)
            => services.AddCors(options =>
            {
                options.AddPolicy("AllowReadOnlySpecificOrigins", builder =>
                {
                    builder.AllowAnyHeader();
                    builder.WithMethods("GET");

                    if (_environment.IsDevelopment())
                    {
                        builder.AllowAnyOrigin();
                    }
                    else
                    {
                        builder.WithOrigins(_configuration["CorsOrigins"]);
                    }
                });
            });

        /// <summary>
        /// Configure settings for use of entity framework.
        /// </summary>
        private void ConfigureEntityFramework(IServiceCollection services)
        {
            string connectionString = _configuration["Database:ConnectionString"];
            services.AddDbContext<SampleContext>(options => options.UseSqlServer(connectionString));
        }

        /// <summary>
        /// Configure settings for use of IOptions.
        /// </summary>
        private void ConfigureSettings(IServiceCollection services)
            => services.Configure<Database>(options => _configuration.GetSection("Database").Bind(options));
    }
}