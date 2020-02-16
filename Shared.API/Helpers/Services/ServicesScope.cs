using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shared.API.Helpers.Middleware;
using Shared.Core.Interfaces;
using Shared.Core.Interfaces.Employess;
using Shared.Core.Interfaces.IUsers;
using Shared.Infrastructure.Data;
using Shared.Infrastructure.Persistence;
using Shared.Infrastructure.Persistence.EmployeesRepository;
using Shared.Infrastructure.Persistence.UsersRepository;
using Shared.Services.EmployeeServices;
using Shared.Services.Helpers.HelperClasses;
using Shared.Services.Helpers.Jwt;
using Shared.Services.Helpers.Jwt.Interfaces;
using Shared.Services.JwtServices;
using Shared.Services.UsersServices;
using Shared.Services.ViewModels.ServicesViewModel;

namespace Shared.API.Helpers.Services
{
    public static class ServicesScope
    {
        public static IServiceCollection InitAuthentication(this IServiceCollection services, IConfigurationSection jwtAppSettingOptions,
            SymmetricSecurityKey signingKey)
        {
           var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            });


            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],
                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(configureOptions =>
            {
                configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.SaveToken = true;
                 configureOptions.SecurityTokenValidators.Clear();
                 configureOptions.SecurityTokenValidators.Add(new TokenValidationHandler(signingCredentials));
            });

            // api user claim policy
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiUser", policy => policy.RequireClaim("role", "api_access"));
            });

            return services;
        }
        public static IServiceCollection InitLocalization(this IServiceCollection services)
        {
            services.AddLocalization(o => o.ResourcesPath = "Resources");

            services.Configure<RequestLocalizationOptions>(options =>
            {
                CultureInfo[] supportedCultures = new[]
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("ar")
                };

                options.DefaultRequestCulture = new RequestCulture("en-US");

                // You must explicitly state which cultures your application supports.
                // These are the cultures the app supports for formatting 
                // numbers, dates, etc.
                options.SupportedCultures = supportedCultures;

                // These are the cultures the app supports for UI strings, 
                // i.e. we have localized resources for.
                options.SupportedUICultures = supportedCultures;

                options.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider(),
                    new AcceptLanguageHeaderRequestCultureProvider()
                };
            });

            return services;
        }
        public static IServiceCollection InitMvc(this IServiceCollection services)
        {
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix, opts => { opts.ResourcesPath = "Resources"; })
                .AddDataAnnotationsLocalization();
            return services;
        }
        public static IServiceCollection InitCors(this IServiceCollection services)
        {
            // CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AnyOrigin",
                    builder =>
                        builder
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowAnyOrigin()
                            .AllowCredentials()
                );
            });

            return services;
        }

        public static IServiceCollection AddCache(this IServiceCollection services)
        {
            services.AddMemoryCache();
            return services;
        }

        public static IServiceCollection InitContext(this IServiceCollection services, string connectionString)
        {
            // Context
            services.AddDbContext<SharedContext>(options => options.UseOracle(connectionString));
            return services;
        }

        public static IServiceCollection InitDependenciesInjection(this IServiceCollection services)
        {
            services
                .AddScoped<UserService>()
                .AddScoped<EmployeeServices>()
                .AddSingleton<JwtIssuerOptions>()
                .AddScoped<JsonParser>()
                .AddScoped<MachineInfoService>()
                .AddScoped<UsersServices>()
                .AddScoped<JwtServices>()
                .AddScoped<TokenValidationHandler>()
                .AddSingleton<ApiService>()
                .AddScoped<IUsersRepository, UsersRepository>()
                .AddScoped<IEmployeeRepository, EmployeeRepository>()
                .AddScoped<IJwtFactory, JwtFactory>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped(typeof(IRepo<>), typeof(Repo<>))
                  .AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }



        public static IServiceCollection InitCookies(this IServiceCollection services)
        {
            services.ConfigureExternalCookie(config =>
            {
                config.Cookie.Name = "_t";
                config.Cookie.IsEssential = false;
                config.Cookie.HttpOnly = true;
                config.Cookie.SecurePolicy = CookieSecurePolicy.None;
                config.Cookie.SameSite = SameSiteMode.None;
            });

            return services;
        }

        public static IApplicationBuilder InitStartup(this IApplicationBuilder app, bool isDevelopment = false)
        {
            if (isDevelopment)
                app.UseDeveloperExceptionPage();
            else
            {
                app.UseHsts();
            }

            app
                .UseDefaultFiles()
                .UseStaticFiles()
                .UseRequestLocalization(
                    app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value)
                .UseCors("AnyOrigin");
          //.UseMvc(routes =>
          //    {
          //        routes.MapRoute("api", "api/{controller}/{action=Index}/{id?}");
          //        routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
          //    });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hr Core  API V1");
            });
            app.UseMiddleware<HrSharedRequestMiddleware>();
            app.UseHttpsRedirection();
            app.UseMvc();

            return app;
        }
    }
}
