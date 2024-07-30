using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Container;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DreamTravel.Models;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;

namespace DreamTravel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //////////////////////////////////////////////////

            //builder.Services.AddLogging(x =>
            //{
            //    x.ClearProviders();
            //    x.SetMinimumLevel(LogLevel.Debug);
            //    x.AddDebug();
            //});



            builder.Services.AddAutoMapper(typeof(Program));


            builder.Services.AddDbContext<Context>();

            builder.Services.AddIdentity<AppUser, AppRole>(_ =>
            {

                _.Password.RequiredLength = 8;
                _.Password.RequireNonAlphanumeric = false;
                _.Password.RequireLowercase = false;
                _.Password.RequireUppercase = false;
                _.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<Context>()
            .AddErrorDescriber<CustomIdentityValidator>();

            builder.Services.ContainerDependencies();
            builder.Services.CustomValidator();

            builder.Services.AddControllersWithViews().AddFluentValidation();

            builder.Services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder().
                RequireAuthenticatedUser().
                Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });


            //////////////////////////////////////////////////
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run();
        }
    }
}