using System.Globalization;
using System.Linq;
using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaDeVenda.Server.Infra;
using SistemaDeVenda.Server.Infra.Seed;
using Tempus.Utils.AspNetCore;

namespace SistemaDeVenda.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Enviroment = environment;          
            
        }

        public IConfiguration Configuration { get; }
        

        public IHostingEnvironment Enviroment { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           

            services
                .AddMvc(opt =>
                {
                    opt.Filters.Add(typeof(JsonApiValidationActionFilter));
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddFeatureFolders().AddJsonOptions(opts =>
                {
                    opts.SerializerSettings.Culture = CultureInfo.InvariantCulture;
                    opts.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            services.AddDbContext<SistemaDeVendaContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("SistemaDeVenda")));

            services.AddMediatR();

            services.AddApplicationInsightsTelemetry();          

            //services.AddCors();
            services.AddCors(opts =>
            {
                //opts.AddPolicy("default", policy =>
                //{
                //    policy.WithOrigins("http://localhost:3333")
                //        .AllowAnyHeader()
                //        .AllowAnyMethod()
                //        .AllowAnyOrigin();
                //});

                opts.AddPolicy("Development", o => o.WithOrigins("http://localhost:3333").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            });

            services.AddScoped<IDbInitializer, DbInitializer>();

            services.AddHttpContextAccessor();           

            RegisterValidators(services);
        }

        private void RegisterValidators(IServiceCollection services)
        {
            var assembly = typeof(Startup).GetTypeInfo().Assembly;
            var validatorType = typeof(IValidator);

            var validators = assembly
                .GetExportedTypes()
                .Where(t => validatorType.IsAssignableFrom(t) && !t.IsInterface);

            foreach (var validator in validators)
            {
                services.AddTransient(validator);

                var validatorInterfaces = validator
                    .GetInterfaces()
                    .Where(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IValidator<>));

                foreach (var validatorInterface in validatorInterfaces)
                {
                    services.AddTransient(validatorInterface, validator);
                }
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IDbInitializer dbInitializer)
        {
            app.UseCors("default");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseCors("Development");
            }
            else
            {
                app.UseHsts();

                app.UseHttpsRedirection();
            }
           

            if (env.IsProduction())
            {
                app.UseDefaultFiles();
                app.UseStaticFiles(new StaticFileOptions
                {
                    OnPrepareResponse = OnStaticFilePrepareResponse
                });
            }           

            app.UseMvc(opts =>
            {
                opts.MapRoute(
                    name: "default",
                    template: "api/{controller}/{action}/{id?}");
            });

            if (env.IsDevelopment())
            {
                app.UseWelcomePage();
            }
        }

        private void OnStaticFilePrepareResponse(StaticFileResponseContext context)
        {
            if (context.File.Name.StartsWith("chunk-")
                || context.File.Name.EndsWith(".entry.js")
                || context.File.Name.EndsWith(".svg"))
            {
                context.Context.Response.Headers.Add("Cache-Control", "must-revalidate, max-age=604800");
                context.Context.Response.Headers.Add("Pragma", "no-cache");
                context.Context.Response.Headers.Add("Expires", "604800");
                return;
            }

            // Apply cache with revalidation
            if (context.File.Name.EndsWith(".html")
                || context.File.Name.EndsWith(".json")
                || context.File.Name.EndsWith(".js")
                || context.File.Name.EndsWith(".map")
                || context.File.Name.EndsWith(".css")
            )
            {
                context.Context.Response.Headers.Add("Cache-Control", "no-cache, must-revalidate");
                context.Context.Response.Headers.Add("Pragma", "no-cache");
                context.Context.Response.Headers.Add("Expires", "0");
            }
        }
    }
}