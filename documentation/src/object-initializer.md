# Initializer

## Index Initializers

Use index initializers with dictionary.
This elegantly prevents uninitialized dictionaries.

[Object and Collection Initializers (C# Programming Guide)]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers#object-initializers-with-collection-read-only-property-initialization

```csharp
var dict = new Dictionary<string, int>
{
    ["key1"] = 1,
    ["key2"] = 50,
};
```

*Not so good example*
```csharp
var dict = new Dictionary<string, int>();
dict["key1"] = 1;
dict["key2"] = 50;
```

*Deprecated way example*
```csharp
var dict = new Dictionary<string, int>
{
    { "key1", 1 },
    { "key2", 50 },
};
```
