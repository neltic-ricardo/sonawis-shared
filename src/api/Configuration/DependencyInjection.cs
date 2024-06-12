using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sonawis.Shared.Infrastructure.Helpers;
using Sonawis.Shared.Infrastructure;

namespace Sonawis.Shared.Api.Configuration;
public static class DependencyInjection
{
    public static IServiceCollection InstallServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var assemblies = AssemblyHelper.GetAssemblies("Api");

        var type = typeof(IServiceInstaller);

        var serviceInstallers = assemblies
            .SelectMany(a => a.ExportedTypes)
            .Where(a => a.IsAssignableToType<IServiceInstaller>())
            .Select(Activator.CreateInstance)
            .Cast<IServiceInstaller>();


        foreach (IServiceInstaller serviceInstaller in serviceInstallers)
            serviceInstaller.Install(services, configuration);

        return services;        
    }
}
