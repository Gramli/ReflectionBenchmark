namespace ReflectionBenchmark.GenericExport
{
    public sealed class CustomLargeItem
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
        [CsvHeader("Item8")]
        public int Item8 { get; init; }
        [CsvHeader("Item9")]
        public long Item9 { get; init; }
        [CsvHeader("Item10")]
        public DateTime Item10 { get; init; }
        [CsvHeader("Item11")]
        public TimeSpan Item11 { get; init; }
        [CsvHeader("Item12")]
        public double Item12 { get; init; }
        [CsvHeader("Item13")]
        public float Item13 { get; init; }
        [CsvHeader("Item14")]
        public string Item14 { get; init; } = string.Empty;
        [CsvHeader("Item15")]
        public float Item15 { get; init; }
        [CsvHeader("Item16")]
        public string Item16 { get; init; } = string.Empty;
    }
}
