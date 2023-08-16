using System.Text;

namespace ReflectionBenchmark.GenericExport.CsvExport
{
    public static class CsvItemExport
    {
        private static readonly IList<string> Headers = new List<string>
        {
            "Item1","Item2","Item3","Item4","Item5","Item6","Item7","Item8","Item9","Item10","Item11","Item12","Item13","Item14","Item15","Item16",
        };
        public static string ExportToCsvFast(this IEnumerable<CustomItem> items, string separator = ";")
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
                //TODO More appends instead of interpolation
                var row = @$"{item.Item1}{separator}
                    {item.Item2}{separator}
                    {item.Item3}{separator}
                    {item.Item4}{separator}
                    {item.Item5}{separator}
                    {item.Item6}{separator}
                    {item.Item7}{separator}
                    {item.Item8}{separator}
                    {item.Item9}{separator}
                    {item.Item10}{separator}
                    {item.Item11}{separator}
                    {item.Item12}{separator}
                    {item.Item13}{separator}
                    {item.Item14}{separator}
                    {item.Item15}{separator}
                    {item.Item16}{separator}";

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
