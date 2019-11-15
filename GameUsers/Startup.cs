using GameUsers.Core.Interfaces;
using GameUsers.Data.Repositories;
using GameUsers.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;

namespace GameUsers
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
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder => builder.SetIsOriginAllowed(IsOriginAllowed)
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .AllowCredentials());
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton(typeof(IRepository<User>), typeof(MockUserRepository));
            services.AddSingleton(typeof(IRepository<LeaderboardEntry>), typeof(MockLeaderBoardEntryRepository));
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseCors();
            app.UseMvc();
        }

        private static bool IsOriginAllowed(string host) {
            return Regex.IsMatch(host, @"^http://.*:4200$", RegexOptions.IgnoreCase);
        }
    }
}
