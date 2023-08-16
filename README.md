# IN PROGRESS

# ReflectionBenchmar
Reflection is a very powerful tool for determining objects during run-time, but it takes performance. There is a widely held opinion throughout the community that reflection is bad and should not be used, but in my opinion there are a lot of business cases when the reflection is the cleanest and simplest solution, of course I am not talking about high performance applications where the performance is on the first place.

# Menu

* [Motivation](#motivation)
* [Get Started](#get-started)

# Motivation

I was curious how fast are some of my daily basis extension methods which use reflection.

# Get Started
Simply Start console app with **Release** configuration.

# Measure One - Get Enum Value Attribute
Sometimes we need human explanation of enum values and one of the simplest solution is to use attribute. Reflection is nice way to extract attribut from enum value, so in this benchmark measure we can see results of extensions generic method which gets custom attribute from enum value.

```C#
    public static class EnumExtensions
    {
        public static T GetCustomAttribute<T>(this Enum customEnumValue) where T : Attribute
        {
            return customEnumValue
                .GetType()
                .GetMember(customEnumValue.ToString())
                .First()
                .GetCustomAttribute<T>()!;
        }
    }
```

Benchmark shows result of three enums with different sizes and also GetCustomAttribute reflection method which is called in for loop.
* **CustomLargeEnum** with 35 values 
* **CustomEnum** with 16 values
* **CustomSmallEnum** with 6 values

To be able to compare with some fast solution I create static Dictionary -> Map with CustomEnum as key and string as value which represents description.

```C#
    public static class CustomEnumMap
    {
        public static readonly IDictionary<CustomEnum, string> Map = new Dictionary<CustomEnum, string>()
        {
			...
        };
    }
```

![Measure One - Get Enum Attribute](./doc/img/getEnumAttribute.png)

### Summary
As we can see implementation with **Dictionary** is much faster and do not allocate memory when we try to get value by key, but it has to be edited every time we add a new item to Enum.
**Reflection** is slower (but don't forger that we are still talking about nanoseconds so process 25K items takes 33 milliseconds) and allocate memory in consequence of which runs GC. In the case of 25k items it is a lot of garbage collections and allocated memory. On the other hand with relfection we don't care about Enum editing.

**In my opinion for this case we can use reflection, but responsibly, for small portion of GetCustomAttribute calls is totally OK and we don't have to remember to edit our code every time we edit enum, but for a bunch of data, reflection is not sufficient because of memory allocations and garbage collections.**


# Measure Two - Export Data by Reflection
Export to .csv, .xlsx, .ods file formats is standard for a lot of business applications and for that we can use generic export method with custom attribute representing header.

![Measure One - Get Enum Attribute](./doc/img/genericExport.png)

# Measure Three
