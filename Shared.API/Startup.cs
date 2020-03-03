using System;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Shared.API.Helpers.Services;
using Shared.Services.JwtServices;
using Shared.Services.JwtServices.Jwt;
using Swashbuckle.AspNetCore.Swagger;

namespace Shared.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecurityKey"]));
        }

        public IConfiguration Configuration { get; }
        private readonly SymmetricSecurityKey _signingKey;
        private readonly JwtServices _jwtServices;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .InitDependenciesInjection()
                .InitCors()
                .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
                .InitContext(Configuration.GetConnectionString("SharedConnection"))
                 .InitAuthentication(Configuration.GetSection(nameof(JwtIssuerOptions)), _signingKey)
                .InitLocalization()
                .AddCache()
                .InitMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Shared Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.InitStartup(env.IsDevelopment());
        }
    }
}
