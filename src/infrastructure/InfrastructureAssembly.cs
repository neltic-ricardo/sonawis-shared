﻿using System.Reflection;

namespace Sonawis.Shared.Infrastructure;
public static class InfrastructureAssembly
{
    public static readonly Assembly Instance = typeof(InfrastructureAssembly).Assembly;
}
