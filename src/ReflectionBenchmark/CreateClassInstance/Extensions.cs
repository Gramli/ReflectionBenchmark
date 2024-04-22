using System.Reflection;

namespace ReflectionBenchmark.CreateClassInstance
{
    internal static class Extensions
    {
        internal static Type GetTypeByInterfaceSingle(this Assembly assembly, Type interfaceType)
           => assembly.DefinedTypes
                .Single(t=>t.IsClass && 
                    t.ImplementedInterfaces.Any(x=>!string.IsNullOrEmpty(x.FullName) && x.FullName.Equals(interfaceType.FullName)));
    }
}
