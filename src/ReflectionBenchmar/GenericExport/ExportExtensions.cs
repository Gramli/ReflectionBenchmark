using System.Collections;

namespace ReflectionBenchmark.GenericExport
{
    public static class ExportExtensions
    {
        public static bool IsEnd<T>(this IList<T> array, int index)
            => index == array.Count - 1;
    }
}
