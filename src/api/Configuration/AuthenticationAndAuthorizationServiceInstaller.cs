using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Sonawis.Shared.Infrastructure.Authentication.OptionsSetup;
using Sonawis.Shared.Infrastructure.Authentication.Permissions;

namespace Sonawis.Shared.Api.Configuration;
public class AuthenticationAndAuthorizationServiceInstaller : IServiceInstaller
{
    public void Install(
        IServiceCollection services, 
        IConfiguration configuration)
    {
        // Add services to the container.

        var policy = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .Build();

        services.AddControllers(configure =>
        {
            configure.Filters.Add(new AuthorizeFilter(policy));
        });


        services.ConfigureOptions<JwtOptionsSetup>();
        services.ConfigureOptions<JwtBearerOptionsSetup>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                        .AddJwtBearer();

        services.AddAuthorization();
        services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
        services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();

    }
}
