namespace ReflectionBenchmark.CreateClassInstance
{
    internal class SomeJob : ISomeJob
    {
        private readonly int _timeout;
        public SomeJob(int timeout) 
        {
            _timeout = timeout;
        }

        public async Task DoWorkAsync()
        {
           await Task.Delay(_timeout);
        }
    }
}
