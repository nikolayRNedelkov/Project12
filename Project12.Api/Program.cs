using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Project12.Repositories.Base;
using Project12.Repositories.Base.Contracts;
using Project12.Repositories.Repos;
using Project12.Repositories.Repos.Contracts;
using Project12.Services;
using Project12.Services.Base.Contracts;
using Project12.Services.Base;
using Project12.Services.Contracts;
using System;
using AutoMapper;
using Project12.Utilities.Mapper;
using Project12.Repositories.Models.Users;
using Project12.Repositories.Models.Roles;
using Microsoft.Extensions.DependencyInjection;

namespace Project12.Api
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("SQLServerDatabase");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new Exception("Missing connection string configuration");
            }

            builder.Services.AddDbContext<ProjectDbContext>((p, options) =>
                options.UseLazyLoadingProxies()
                    .UseSqlServer(
                         connectionString,
                         providerOptions =>
                         {
                             providerOptions.EnableRetryOnFailure(
                                 maxRetryCount: 10,
                                 maxRetryDelay: TimeSpan.FromSeconds(5),
                                 errorNumbersToAdd: null);
                             providerOptions.CommandTimeout(60);
                         }));

            builder.Services.AddAuthorization();

            builder.Services.AddIdentity<User, Role>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 5;
                options.Lockout.MaxFailedAccessAttempts = 5;
            })
            .AddEntityFrameworkStores<ProjectDbContext>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Login";
                options.LogoutPath = "/Identity/Logout";
            });

            // Add services to the container.
            builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

            builder.Services.AddSingleton(new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile())));
            builder.Services.AddScoped(x => x.GetRequiredService<MapperConfiguration>().CreateMapper());

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddTransient<IUserData, UserData>();
            builder.Services.AddScoped<IDbEngine>(x => new DbEngine(connectionString));

            RegisterRepositories(builder.Services);
            RegisterServices(builder.Services);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection()
               .UseCookiePolicy()
               .UseStaticFiles()
               .UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { Controller = "Identity", action = "Login" });
            });

            app.Run();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
        }
    }
}