using System.Reflection;

namespace Sonawis.Shared.Api;

public static class ApiAssembly
{
    public static readonly Assembly Instance = typeof(ApiAssembly).Assembly;
}