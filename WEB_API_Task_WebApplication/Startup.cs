using System.IO;
using Database;
using Database.Extensions;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WEB_API_Task_WebApplication.Loggers;

namespace WEB_API_Task_WebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EnterpriseContext>(mydbvar => mydbvar.UseInMemoryDatabase("Enterprise"));
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddIdentity<IdentityUser, IdentityRole>();
            services.AddAuthentication(
                v =>
                {
                    v.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
                    v.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;

                }).AddGoogle(googleOptions =>
                {
                    googleOptions.ClientId = "512460486507-acq02h8reu9f0f3nq165sinhq3bedn9e.apps.googleusercontent.com";
                    googleOptions.ClientSecret = "VEl8M_7f_sWLsZH8_p6i8naz";
                });                                   
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseAuthentication();
            app.UseMvc();

             loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(),"log.txt"));
            var logger = loggerFactory.CreateLogger("FileLogger");

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<EnterpriseContext>();
                context.EnsureSeedData();
            }
        }
    }
}
