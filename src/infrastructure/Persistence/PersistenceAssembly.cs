using System.Reflection;

namespace Sonawis.Shared.Persistence;

public static class PersistenceAssembly
{
    public static readonly Assembly Instance = typeof(PersistenceAssembly).Assembly;
}
