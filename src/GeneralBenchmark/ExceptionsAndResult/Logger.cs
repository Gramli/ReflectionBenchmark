namespace GeneralBenchmark.ExceptionsAndResult
{
    public sealed class Logger
    {
        public static readonly Logger Instance = new();

        public string? Log(Exception ex)
        {
            return ex.ToString();
        }

        public string? Log(IEnumerable<string> errors)
        {
            return errors.ToString();
        }
    }
}
