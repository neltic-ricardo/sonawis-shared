using System.Reflection;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sonawis.Shared.Api.Configuration;
public class MediatRServiceInstaller : IServiceInstaller
{
    public void Install(
        IServiceCollection services, 
        IConfiguration configuration)
    {
        List<Assembly> assemblies = new();

        var assemblyNames = Directory
                .EnumerateFiles(AppContext.BaseDirectory, "*Sonawis*")
                .Where(a => a.EndsWith("dll"));

        foreach (var assemblyName in assemblyNames)
            assemblies.Add(Assembly.LoadFrom(assemblyName));

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies.ToArray()));
    }
}
