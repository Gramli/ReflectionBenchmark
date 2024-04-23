namespace ReflectionBenchmark.GenericExport
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class CsvHeaderAttribute : Attribute
    {
        public string Header { get; private set; } 

        public CsvHeaderAttribute(string header)
        {
            Header = header;
        }
    }
}
