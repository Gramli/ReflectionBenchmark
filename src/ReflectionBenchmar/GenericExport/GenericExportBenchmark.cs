using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace ReflectionBenchmark.GenericExport
{
    [SimpleJob(RuntimeMoniker.Net70)]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class GenericExportBenchmark
    {
        public IEnumerable<GenericExportBenchmarkData> Data()
        {
            yield return new GenericExportBenchmarkData(10);
            yield return new GenericExportBenchmarkData(100);
            yield return new GenericExportBenchmarkData(1000);
            yield return new GenericExportBenchmarkData(5000);
            yield return new GenericExportBenchmarkData(10000);
            yield return new GenericExportBenchmarkData(25000);
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public void CustomItem(GenericExportBenchmarkData data)
        {

            var _ = data.Items.ExportToCsv();
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public void CustomLargeItem(GenericExportBenchmarkData data)
        {
            var _ = data.LargeItems.ExportToCsv();
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public void CustomSmallItem(GenericExportBenchmarkData data)
        {
            var _ = data.SmallItems.ExportToCsv();
        }
    }
}
