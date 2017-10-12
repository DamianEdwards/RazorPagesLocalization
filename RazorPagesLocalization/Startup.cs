using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using RazorPagesLocalization.Services;

namespace RazorPagesLocalization
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
            services.AddMvc()
                .AddViewLocalization(options => options.ResourcesPath = "Resources");

            // Add patched IViewLocalizer
            services.AddTransient<Microsoft.AspNetCore.Mvc.Localization.IViewLocalizer, ViewLocalizer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            var locOptions = new RequestLocalizationOptions();
            locOptions.SupportedCultures.Add(new CultureInfo("en-US"));
            locOptions.SupportedCultures.Add(new CultureInfo("es-ES"));
            locOptions.SupportedUICultures.Add(new CultureInfo("en-US"));
            locOptions.SupportedUICultures.Add(new CultureInfo("es-ES"));
            locOptions.DefaultRequestCulture = new RequestCulture("en-US", "en-US");
            app.UseRequestLocalization(locOptions);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
