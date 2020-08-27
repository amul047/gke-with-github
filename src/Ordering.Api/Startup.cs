using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ordering.Api.Services;
using Ordering.Api.Services.Interfaces;
using Ordering.Api.Services.Settings;

namespace Ordering.Api
{
    public class Startup
    {
        public const string AllowAnyOriginPolicy = "AllowAnyOriginPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(
                options =>
                {
                    options.AddPolicy(
                        AllowAnyOriginPolicy,
                        builder =>
                        {
                            builder.AllowAnyOrigin();
                        });
                });

            services.AddControllers();

            services.AddScoped<IPricingService, PricingService>();
            services.Configure<SupplierApiSettings>(Configuration.GetSection(nameof(SupplierApiSettings)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(AllowAnyOriginPolicy);

            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}