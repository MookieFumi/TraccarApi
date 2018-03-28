using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TraccarApi.Business;
using TraccarApi.Services;

namespace TraccarApi
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
            string connectionString = Configuration["ConnectionStrings:TraccarContext"];

            services
                .AddEntityFrameworkMySql()
                .AddDbContext<TraccarContext>(optionsAction: opt =>
                {
                    opt.UseMySql(connectionString);
                });

            services.AddMvc();

            services.AddTransient<IEventsService, EventsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // app.UseStaticFiles();

            // app.UseRequestResponseLoggingMiddleware();

            // app.UseRequestLocalization(GetRequestLocalizationOptions());
            app.UseMvcWithDefaultRoute();
        }
    }
}
