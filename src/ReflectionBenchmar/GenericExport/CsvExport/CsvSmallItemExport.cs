using System.Text;

namespace ReflectionBenchmark.GenericExport.CsvExport
{
    public static class CsvSmallItemExport
    {
        private static readonly IList<string> Headers = new List<string>
        {
            "Item1","Item2","Item3","Item4","Item5","Item6","Item7",
        };
        public static string ExportToCsvFast(this IEnumerable<CustomSmallItem> items, string separator = ";")
        {
            if (items is null || !items.Any())
            {
                throw new ArgumentNullException(nameof(items));
            }

            var result = new StringBuilder();

            var headers = GetHeaders(separator);
            result.AppendLine(headers);

            foreach (var item in items)
            {
                result.AppendLine();
                var row = @$"{item.Item1}{separator}
                    {item.Item2}{separator}
                    {item.Item3}{separator}
                    {item.Item4}{separator}
                    {item.Item5}{separator}
                    {item.Item6}{separator}
                    {item.Item7}";

                result.Append(row);
            }

            return result.ToString();
        }

        private static string GetHeaders(string separator)
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < Headers.Count; i++)
            {
                stringBuilder.Append(Headers[i]);

                if (!Headers.IsEnd(i))
                {
                    stringBuilder.Append(separator);
                }
            }

            return stringBuilder.ToString();
        }
    }
}
