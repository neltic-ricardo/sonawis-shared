using System.Reflection;

namespace Sonawis.Shared.Domain;
public static class DomainAssembly
{
    public static readonly Assembly Instance = typeof(DomainAssembly).Assembly;
}
