using Microsoft.Diagnostics.Runtime.Utilities;
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
                result.AppendByProperty(item, separator);
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

        private static void AppendInterpolation(this StringBuilder stringBuilder, CustomLargeItem item, string separator)
        {
            stringBuilder.AppendLine();
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

            stringBuilder.Append(row);
        }

        private static void AppendByProperty(this StringBuilder stringBuilder, CustomLargeItem item, string separator)
        {
            stringBuilder.Append($"{item.Item1}{separator}");
            stringBuilder.Append($"{item.Item2}{separator}");
            stringBuilder.Append($"{item.Item3}{separator}");
            stringBuilder.Append($"{item.Item4}{separator}");
            stringBuilder.Append($"{item.Item5}{separator}");
            stringBuilder.Append($"{item.Item6}{separator}");
            stringBuilder.Append($"{item.Item7}{separator}");
            stringBuilder.Append($"{item.Item8}{separator}");
            stringBuilder.Append($"{item.Item9}{separator}");
            stringBuilder.Append($"{item.Item10}{separator}");
            stringBuilder.Append($"{item.Item11}{separator}");
            stringBuilder.Append($"{item.Item12}{separator}");
            stringBuilder.Append($"{item.Item13}{separator}");
            stringBuilder.Append($"{item.Item14}{separator}");
            stringBuilder.Append($"{item.Item15}{separator}");
            stringBuilder.Append($"{item.Item16}{separator}");
            stringBuilder.Append($"{item.Item17}{separator}");
            stringBuilder.Append($"{item.Item18}{separator}");
            stringBuilder.Append($"{item.Item19}{separator}");
            stringBuilder.Append($"{item.Item20}{separator}");
            stringBuilder.Append($"{item.Item21}{separator}");
            stringBuilder.Append($"{item.Item22}{separator}");
            stringBuilder.Append($"{item.Item23}{separator}");
            stringBuilder.Append($"{item.Item24}{separator}");
            stringBuilder.Append($"{item.Item25}{separator}");
            stringBuilder.Append($"{item.Item26}{separator}");
            stringBuilder.Append($"{item.Item27}{separator}");
            stringBuilder.Append($"{item.Item28}{separator}");
            stringBuilder.Append($"{item.Item29}{separator}");
            stringBuilder.Append($"{item.Item30}{separator}");
            stringBuilder.Append($"{item.Item31}{separator}");
            stringBuilder.Append($"{item.Item32}{separator}");
        }
    }
}
