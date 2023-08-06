namespace ReflectionBenchmark.GenericExport
{
    public sealed class CustomSmallItem
    {
        [CsvHeader("Item1")]
        public int Item1 { get; init; }
        [CsvHeader("Item2")]
        public long Item2 { get; init; }
        [CsvHeader("Item3")]
        public DateTime Item3 { get; init; }
        [CsvHeader("Item4")]
        public TimeSpan Item4 { get; init; }
        [CsvHeader("Item5")]
        public double Item5 { get; init; }
        [CsvHeader("Item6")]
        public float Item6 { get; init; }
        [CsvHeader("Item7")]
        public string Item7 { get; init; } = string.Empty;
    }
}
