using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Sonawis.Shared.Infrastructure.Authentication.Permissions;
public class PermissionAuthorizationPolicyProvider
    : DefaultAuthorizationPolicyProvider
{
    public PermissionAuthorizationPolicyProvider(
        IOptions<AuthorizationOptions> options)
        : base(options)
    {
    }

    public override async Task<AuthorizationPolicy?> GetPolicyAsync(
        string policyName)
    {
        AuthorizationPolicy? policy = await base.GetPolicyAsync(policyName);

        return policy is not null
            ? policy
            : new AuthorizationPolicyBuilder()
            .AddRequirements(new PermissionRequirement(policyName))
            .Build();
    }
}
