using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Container;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DreamTravel.CQRS.Handlers.DestinationHandlers;
using DreamTravel.Models;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;
using System.Reflection;

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
            builder.Services.AddScoped<GetAllDestinationQueryHandler>();
            builder.Services.AddScoped<GetDestinationByIDQueryHandler>();
            builder.Services.AddScoped<CreateDestinationCommandHandler>();
            builder.Services.AddScoped<RemoveDestinationCommandHandler>();
            builder.Services.AddScoped<UpdateDestinationCommandHandler>();

            builder.Services.AddMediatR(typeof(Program));

            builder.Services.AddHttpClient();

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddDbContext<Context>();

            builder.Services.AddIdentity<AppUser, AppRole>(_ =>
            {

                _.Password.RequiredLength = 8;
                _.Password.RequireNonAlphanumeric = false;
                _.Password.RequireLowercase = false;
                _.Password.RequireUppercase = false;
                _.Password.RequireDigit = false;
            }).AddErrorDescriber<CustomIdentityValidator>().AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider).AddEntityFrameworkStores<Context>();

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

            builder.Services.AddLocalization(opt =>
            {
                opt.ResourcesPath = "Resources";
            });

            builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                options.SetDefaultCulture("tr");
                options.AddSupportedUICultures("zh", "fr" ,"en","tr");
                options.FallBackToParentUICultures = true;
            });

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login/SignIn";
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
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRequestLocalization(); 

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