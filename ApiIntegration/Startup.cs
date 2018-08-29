using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiIntegration.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Text;
using ApiIntegration.Entities;
using ApiIntegration.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiIntegration
{
    public partial class Startup
    {
        private IConfiguration _configuration { get; set; }
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
          //  var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Database=ApiIntegration;Trusted_Connection=True";
            services.AddDbContext<LoginContext>(o => o.UseSqlServer(_configuration.GetConnectionString("ApiIntegration")));
            services.AddScoped<ILoginData,SqlLoginData>();


            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;

                })
                .AddOpenIdConnect(config =>
                {
                    _configuration.Bind("AzureAd",config);
                } )
                .AddCookie();
            services.AddMvc();
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,IHostingEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           // app.UseRewriter(new RewriteOptions().AddRedirectToHttpsPermanent());
            app.UseAuthentication();
            app.UseMvc(ConfigureRoutes);
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            //api/login
            routeBuilder.MapRoute("Default", "{controller=Login}/{action=Create}");
        }
    }
}
