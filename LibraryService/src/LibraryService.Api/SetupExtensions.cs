using LibraryService.Infrastructure.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace LibraryService.Api
{
    public static class SetupExtensions
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, JwtSettings jwtSettings, SecuritySettings securitySettings)
        {
            var encodedKey = Encoding.UTF8.GetBytes(jwtSettings.Key);
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = securitySettings.JwtValidIssuer,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(encodedKey)
                };
            });

            return services;
        }
    }
}