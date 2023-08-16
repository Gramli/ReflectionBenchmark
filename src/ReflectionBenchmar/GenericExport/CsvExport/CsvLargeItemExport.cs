using System.Text;

namespace ReflectionBenchmark.GenericExport.CsvExport
{
    public static class CsvLargeItemExport
    {
        private static readonly IList<string> Headers = new List<string>
        {
           "Item1","Item2","Item3","Item4","Item5","Item6","Item7","Item8","Item9","Item10","Item11","Item12","Item13","Item14","Item15","Item16",
            "Item17","Item18","Item19","Item20","Item21","Item22","Item23","Item24","Item25","Item26","Item27","Item28","Item29","Item30","Item31","Item32",
        };
        public static string ExportToCsvFast(this IEnumerable<CustomLargeItem> items, string separator = ";")
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
                    {item.Item7}{separator}
                    {item.Item8}{separator}
                    {item.Item9}{separator}
                    {item.Item10}{separator}
                    {item.Item11}{separator}
                    {item.Item12}{separator}
                    {item.Item13}{separator}
                    {item.Item14}{separator}
                    {item.Item15}{separator}
                    {item.Item16}{separator}
                    {item.Item17}{separator}
                    {item.Item18}{separator}
                    {item.Item19}{separator}
                    {item.Item20}{separator}
                    {item.Item21}{separator}
                    {item.Item22}{separator}
                    {item.Item23}{separator}
                    {item.Item24}{separator}
                    {item.Item25}{separator}
                    {item.Item26}{separator}
                    {item.Item27}{separator}
                    {item.Item28}{separator}
                    {item.Item29}{separator}
                    {item.Item30}{separator}
                    {item.Item31}{separator}
                    {item.Item32}{separator}";

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
