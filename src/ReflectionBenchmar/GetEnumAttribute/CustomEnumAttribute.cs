namespace ReflectionBenchmark.GetEnumAttribute
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class CustomEnumAttribute : Attribute
    {
        public string Description { get; }

        public CustomEnumAttribute(string description)
        {
            Description = description;
        }

    }
}
