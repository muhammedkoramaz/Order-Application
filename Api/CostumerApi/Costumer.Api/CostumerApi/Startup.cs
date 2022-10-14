using Costumer.Api.Infastructure;
using Costumer.Api.Models;
using Costumer.Api.Services;
using CostumerApi.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace CostumerApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [System.Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CustomerDatabaseSettings>(
            Configuration.GetSection(nameof(CustomerDatabaseSettings)));

            services.AddSingleton<ICustomerDatabaseSettings>(sp =>
            sp.GetRequiredService<IOptions<CustomerDatabaseSettings>>().Value);

            services.AddControllers()
                .AddFluentValidation(i => i.DisableDataAnnotationsValidation = true);
                

            services.AddSingleton<ICustomerService, CustomerService>(); //ne zaman bu interface e ihtiya� duyarsam bu class� yarat.

            //VALIDATOR DI
            services.AddTransient<IValidator<Costumer.Api.Models.Customer>, CreateCustomerValidator>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CustomerApi", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:7001");
                                  });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CostumerApi v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
