using Microsoft.AspNetCore.Authorization;

namespace Sonawis.Shared.Infrastructure.Authentication.Permissions;
public class PermissionRequirement : IAuthorizationRequirement
{
    public PermissionRequirement(string permission)
    {
        Permission = permission;
    }

    public string Permission { get; }
}
