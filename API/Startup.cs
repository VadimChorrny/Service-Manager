using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using Core.Entities.UserEntity;
using Infrastructure;
using Core;
using Core.Helpers;
using API.Middlewares;
using Core.Interfaces.CustomInterfaces;
using Core.Services;

namespace API
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

            services.AddControllers();

            services.AddCors();

            services.AddDbContext(Configuration.GetConnectionString("DefaultConnection"));

            services.AddIdentity();

            services.AddHttpClient();

            services.AddCustomServices();

            services.Configure<JwtOptions>(Configuration.GetSection(nameof(JwtOptions)));

            services.AddAutoMapper();

            services.AddRepository();

            services.AddUnitOfWork();

            services.AddResponseCaching();

            services.AddJwtAuthentication(Configuration);

            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["FacebookAuthSettings:AppId"];
                facebookOptions.AppSecret = Configuration["FacebookAuthSettings:AppSecret"];
                facebookOptions.AccessDeniedPath = "/AccessDeniedPathInfo"; // maybe need remove
            });

            services.AddAuthentication().AddGoogle(opts =>
            {
                opts.ClientId = Configuration["Google:ClientId"];
                opts.ClientSecret = Configuration["Google:ClientSecret"];
                opts.SignInScheme = IdentityConstants.ExternalScheme;
            });

            services.AddCors(x =>
            {
                x.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer YOUR_BEARER_KEY\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                 {
                     new OpenApiSecurityScheme {
                      Reference = new OpenApiReference {
                      Type = ReferenceType.SecurityScheme,
                      Id = "Bearer"
                }
                },
            new string[] {}
        }
    });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseResponseCaching();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}