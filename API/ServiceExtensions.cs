using Core.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace API
{
    public static class ServiceExtensions
    {
        //public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        //{
        //    var jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();

        //    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        //        .AddJwtBearer(cfg =>
        //        {
        //            cfg.TokenValidationParameters = new TokenValidationParameters()
        //            {
        //                ValidateIssuer = true,
        //                ValidateAudience = false,
        //                ValidateLifetime = true,
        //                ValidateIssuerSigningKey = true,
        //                ValidIssuer = jwtOptions.Issuer,
        //                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key))
        //            };
        //        });
        //}
        public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
            //    options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
            //    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            //})
                .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = jwtOptions.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key))
                };
            });
        }
    }
}
