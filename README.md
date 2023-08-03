# IN PROGRESS

# ReflectionBenchmar


# Menu

* [Motivation](#motivation)
* [Get Started](#get-started)

# Motivation

# Get Started
Simply Start console app with **Release** configuration.

# Measure One - Get Enum Value Attribute
In real world application we sometimes need human explanation of enum values and one of the simplest solution is to use attribute. And for getting that attribute we can use reflection.
So in this benchmark measure we can see results of extensions generic method which gets custom attribute from enum value.

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

Benchmark shows result of three enums with different sizes and also GetCustomAttribute method is called in for loop. 

![Measure One - Get Enum Attribute](./doc/img/getEnumAttribute.png)

# Measure Two - Get Class Property Attribute