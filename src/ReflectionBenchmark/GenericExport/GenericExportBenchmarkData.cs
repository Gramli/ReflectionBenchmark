using AutoFixture;

namespace ReflectionBenchmark.GenericExport
{
    public class GenericExportBenchmarkData
    {
        public IList<CustomLargeItem> LargeItems { get; }
        public IList<CustomItem> Items { get; }
        public IList<CustomSmallItem> SmallItems { get; }

        private readonly int _count;

        public GenericExportBenchmarkData(int count)
        {
            _count = count;
            LargeItems = new List<CustomLargeItem>();
            Items = new List<CustomItem>();
            SmallItems = new List<CustomSmallItem>();

            InitData();
        }

        private void InitData()
        {
            var fixture = new Fixture();

            Console.WriteLine($"Initialize {_count}");
            for(int i = 0; i < _count; i++)
            {
                LargeItems.Add(fixture.Create<CustomLargeItem>());
                Items.Add(fixture.Create<CustomItem>());
                SmallItems.Add(fixture.Create<CustomSmallItem>());
            }
        }

        public override string ToString()
        {
            return $"{_count} items";
        }
    }
}
