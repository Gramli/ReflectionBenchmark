using System.Reflection;
using System.Text;

namespace ReflectionBenchmark.GenericExport
{
    public static class GenericCsvExport
    {
        public static string ExportToCsv<T>(this IEnumerable<T> items, string separator = ",") where T : class
        {
            if (items is null || !items.Any())
            {
                throw new ArgumentNullException(nameof(items));
            }

            var properties = items.First().GetType().GetProperties();

            if (properties is null || !properties.Any())
            {
                throw new ArgumentNullException(nameof(properties));
            }

            var result = new StringBuilder();

            var headers = GetHeaders(properties, separator);
            result.AppendLine(headers);

            foreach (var item in items)
            {
                result.AppendLine();
                for (var i = 0; i < properties.Length; i++)
                {
                    result.Append(properties[i].GetValue(item));

                    if (!properties.IsEnd(i))
                    {
                        result.Append(separator);
                    }
                }
            }

            return result.ToString();
        }

        private static string GetHeaders(PropertyInfo[] properties, string separator)
        {
            var stringBuilder = new StringBuilder();
            for (var i  = 0; i < properties.Length; i++)
            {
                var headerAttribute = properties[i].GetCustomAttribute<CsvHeaderAttribute>();

                if (headerAttribute is null)
                {
                    throw new ArgumentNullException(nameof(CsvHeaderAttribute));
                }

                stringBuilder.Append(headerAttribute.Header);

                if(!properties.IsEnd(i))
                {
                   stringBuilder.Append(separator);
                }
            }

            return stringBuilder.ToString();
        }

        private static bool IsEnd(this Array array, int index)
            => index == array.Length - 1;
    }
}
