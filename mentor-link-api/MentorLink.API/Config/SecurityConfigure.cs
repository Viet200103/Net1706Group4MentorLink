using System.Text;
using MentorLink.API.Security;
using MentorLink.API.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace MentorLink.API.Config;

public static class SecurityConfigure
{
    public static void ConfigureAuthJwt(IConfiguration configuration, IServiceCollection services)
    {
        var authenticationBuilder = services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        });

        var jwtSection = configuration.GetSection("JwtOptions");

        authenticationBuilder.AddJwtBearer(options =>
        {
            var jwtOptions = jwtSection.Get<JwtOptions>() ??
                             throw new Exception($"Missing <{nameof(JwtOptions)}> section.");
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = jwtOptions.ValidAudience,
                ValidIssuer = jwtOptions.ValidIssuer,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),
                ClockSkew = TimeSpan.Zero
            };

            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    string? authCookie = context.Request.Cookies[Contants.AccessToken];
                    if (!authCookie.IsNullOrEmpty())
                    {
                        context.Token = authCookie;
                    }

                    return Task.CompletedTask;
                }
            };
        });
    }
}