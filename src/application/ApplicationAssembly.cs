using System.Reflection;

namespace Sonawis.Shared.Application;

public static class ApplicationAssembly
{
    public static readonly Assembly Instance = typeof(ApplicationAssembly).Assembly;
}
