using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CoreWebAppSandbox
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            //.AddCookie(options =>
            //{
            //    options.Events = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
            //    {
            //        OnValidatePrincipal = context =>
            //        {
            //            var completeJwt = $"{context.Request.Cookies["X-DocuSign-Rooms-Session-Payload"]}.{context.Request.Cookies["X-DocuSign-Rooms-Session-Signature"]}";
            //            new JwtSecurityTokenHandler().ValidateToken(completeJwt, tokenValidationParameters, out var _);
            //            return Task.CompletedTask;
            //        },
            //    };
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(30D);
            //    options.SlidingExpiration = true;
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
