using System;
using System.IO;
using System.Linq;
using System.Reflection;
using FluentValidation.AspNetCore;
using Hahn.ApplicationProcess.May2020.Data.Models;
using Hahn.ApplicationProcess.May2020.Data.Repository;
using Hahn.ApplicationProcess.May2020.Data.RestClient;
using Hahn.ApplicationProcess.May2020.Domain.Services;
using Hahn.ApplicationProcess.May2020.Domain.Validators;
using Hahn.ApplicationProcess.May2020.Web.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;

namespace Hahn.ApplicationProcess.May2020.Web
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
            services.AddControllers();

            services.AddTransient<IApplicantService<Applicant>, ApplicantService>();
            services.AddSingleton<IApplicantRepository<Applicant>, ApplicantRepository>();
            services.AddSingleton<IRestClient, RestClient>();
            //services.AddScoped<ICountryValidator, CountryValidator>();
            services.AddDbContext<ApplicantDatabaseContext>(options =>
                options.UseInMemoryDatabase(Configuration["EntityFramework:DatabaseName"]));

            services.AddMvc(opt =>
            {
                opt.Filters.Add<ExceptionFilter>();
                opt.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<ApplicantValidator>());

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("Hahn.ApplicationProcess.May2020.Web",
                    new OpenApiInfo
                    {
                        Title = "Hahn.ApplicationProcess.May2020.Web",
                        Version = "1"
                    });

                var currentAssembly = Assembly.GetExecutingAssembly();
                var xmlDocs = currentAssembly.GetReferencedAssemblies()
                    .Union(new[] {currentAssembly.GetName()})
                    .Select(a => Path.Combine(Path.GetDirectoryName(currentAssembly.Location), $"{a.Name}.xml"))
                    .Where(f => File.Exists(f)).ToArray();

                Array.ForEach(xmlDocs, d => { options.IncludeXmlComments(d); });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseSerilogRequestLogging();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/Hahn.ApplicationProcess.May2020.Web/swagger.json",
                    "Hahn.ApplicationProcess.May2020.Web");
                options.RoutePrefix = "";
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}