using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace usersecrets_aspnet_example
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();

            //Get User Secrets here
            var username = Configuration["YourService:Username"];
            var password = Configuration["YourService:Password"];


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/",
                    async context =>
                    {
                        await context.Response.WriteAsync(
                            $"Hello. Your successful setup your user secrets. Your username is '{username}'");
                    });
            });
        }
    }
}