using Common.Domain.Constants;
using Common.Infrastructure.Interceptors;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = configuration.GetValue<string>("AuthorityServer:Authority"); // "https://localhost/Identity";
                options.TokenValidationParameters.ValidateAudience = configuration.GetValue<bool>("AuthorityServer:ValidateAudience");//false;
                options.TokenValidationParameters.ValidateIssuer = configuration.GetValue<bool>("AuthorityServer:ValidateIssuer");//true;
                options.TokenValidationParameters.ValidateIssuerSigningKey = configuration.GetValue<bool>("AuthorityServer:ValidateIssuerSigningKey");//true;
                options.TokenValidationParameters.ValidIssuer = configuration.GetValue<string>("AuthorityServer:Authority"); //"https://localhost/Identity";
            });

        services.AddSingleton(TimeProvider.System);

        services.AddAuthorizationBuilder()
            .AddPolicy(Policies.CanPurge, policy => policy.RequireRole(Roles.Administrator));

        return services;
    }
}
