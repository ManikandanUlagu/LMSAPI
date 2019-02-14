
using cba.LoanManagement.Core.Api.Filters;
using cba.LoanManagement.Core.Api.Middleware.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Swashbuckle.AspNetCore.Swagger;
using cba.LoadManagement.BusinessLogic.Interface;
using cba.LoanManagement.Data.Interface;
using cba.LoanManagement.Data;
using cba.LoanManagement.Model;

namespace cba.LoanManagement.Core
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(env.ContentRootPath)
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddMvc();
            services.Configure<IConfigurationRoot>(Configuration);
            services.Configure<AppSetting>(myOptions =>
            {
                myOptions.DatabaseConnectionString = Configuration["LoanManagementDbContext"];
            });
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            services.AddMvc(config => { config.Filters.Add(typeof(CustomExceptionFilter)); });
            // Swagger services.
            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "cba.LoanManagement.Core.Api", Version = "v1" });
                c.OperationFilter<Api.Middleware.SwaggerMiddleware>();
                string xmlDocumentationPath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "cba.LoanManagement.Core.Api.xml");
                if (File.Exists(xmlDocumentationPath))
                {
                    c.IncludeXmlComments(xmlDocumentationPath);
                }
            });

            RegisterDIObject(services);


        }

        public void RegisterDIObject(IServiceCollection services)
        {
            services.AddTransient<ILoanManagement, LoadManagement.BusinessLogic.LoanManagement>();
            services.AddTransient<ILoanManagementRepository, LoanManagementRepository>();

            //For global Exception handling
            services.AddScoped<Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter, CustomExceptionFilter>();
            // Add framework services.
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "cba.LoanManagement.Core.Api");
            });
           // app.UseMiddleware<SecurityHandler>();
            app.UseCors("CorsPolicy");
            app.UseMvc();
           
        }
    }
}
