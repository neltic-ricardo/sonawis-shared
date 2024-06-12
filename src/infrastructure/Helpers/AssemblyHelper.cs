using System.Reflection;

namespace Sonawis.Shared.Infrastructure.Helpers;
public static class AssemblyHelper
{
    public static IEnumerable<Assembly> GetAssemblies(string pattern)
    {
        List<Assembly> assemblies = new();

        var assemblyNames = Directory.EnumerateFiles(AppContext.BaseDirectory, "*Neltic*")
                                     .Where(a => a.EndsWith("dll")) 
                                     .Where(a => a.Contains(pattern));

        foreach (var assemblyName in assemblyNames)
            assemblies.Add(Assembly.LoadFrom(assemblyName));

        return assemblies;
    }
}
