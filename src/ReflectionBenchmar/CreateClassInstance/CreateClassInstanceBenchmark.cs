using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace ReflectionBenchmark.CreateClassInstance
{
    [SimpleJob(RuntimeMoniker.Net70)]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class CreateClassInstanceBenchmark
    {
        [Benchmark(Baseline = true)]
        public void ActivatorCreateInstance()
        {
        }

        [Benchmark]
        public void CreateInstance()
        {
        }
    }
}
