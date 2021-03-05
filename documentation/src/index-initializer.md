# Index Initializer

### Before

```csharp
var dict = new Dictionary<string, int>
{
    { "key1", 1 },
    { "key2", 50 }
};
```
*This code would correspond to:
```csharp
var dict = new Dictionary<string, int>();
dict.Add("key1", 1);
dict.Add("key2", 50);
```

### After

Starting with C#6, collections with indexers can be initialized by specifying the index, like in the following example:

```csharp
var dict = new Dictionary<string, string>
{
    ["Foo"] = "foo",
    ["Bar"] = "bar"
};
```
*This new way of initializing an indexable collections corresponds to:
```csharp
var dict = new Dictionary<string, int>();
dict["key1"] = 1;
dict["key2"] = 50
```

This difference is significant in functionality. The new syntax uses the indexer of the initialized object to assign values instead of using its ```Add()``` method. 
This means the new syntax only requires a publicly available indexer, and works for any object that has one.


#### Example
```csharp
public class IndexableClass
{
    public int this[int index]
    {
        set 
        { 
            Console.WriteLine("{0} was assigned to index {1}", value, index);
        }
    }
}

var foo = new IndexableClass
{
    [0] = 10,
    [1] = 20
}
```