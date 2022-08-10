using Store.Application.Services.Users.Commands.UserSatusChange;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Store.Application.Interfaces.Context;
using Store.Application.Services.Users.Commands.EditUser;
using Store.Application.Services.Users.Commands.RegisterUsers;
using Store.Application.Services.Users.Commands.RemoveUser;
using Store.Application.Services.Users.Queries.GetRoles;
using Store.Application.Services.Users.Queries.GetUsers;
using Store.Persistance.Contexts;
using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Store.Application.Services.Products.FacadPattern;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.Users.UserLogin;
using Store.Application.Services.Users.FacadPattern;
using Store.Application.Services.Queries.GetProductForSite;
using Store.Application.Services.FacadPattern;
using Store.Common.Roles;
namespace Endpoint.Site
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [System.Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAuthorization(options =>
            {
                options.AddPolicy(UserRole.Admin, policy => policy.RequireRole(UserRole.Admin));
                options.AddPolicy(UserRole.Customer, policy => policy.RequireRole(UserRole.Customer));
                options.AddPolicy(UserRole.Operator, policy => policy.RequireRole(UserRole.Operator));
            });
            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = new PathString("/Authentication/Signin");
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
                options.AccessDeniedPath = new PathString("/Authentication/Signin");
            });
            services.AddControllersWithViews();
            services.AddScoped<IDataBaseContext, DataBaseContext>();
            services.AddScoped<IUsersFacad, UsersFacad>();
            services.AddScoped<IProductFacad, ProductFacad>();
            services.AddScoped<IMenueItemFacad, MenueItemFacad>();
            services.AddScoped<ISliderFacad, SliderFacad>();
            services.AddScoped<IAddHomeImageFacad, AddHomeImageFacad>();
            services.AddScoped<ICartFacad, CartFacad>();

            services.AddControllers().AddFluentValidation(s =>
            {
                s.RegisterValidatorsFromAssemblyContaining<Startup>();
                s.RunDefaultMvcValidationAfterFluentValidationExecutes = false;

            });
            services.AddDbContextPool<DataBaseContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("connectionString"));
            });
           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            
           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
               name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");


               


                });
        }
    }
}
