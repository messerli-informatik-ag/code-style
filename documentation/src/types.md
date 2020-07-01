# Types

## Use strong types

C# has a strong typing system, take advantage of it. A strong type will help you a lot in refactoring, and the compiler will easily tell you that you are using the wrong parameter if you do not have a string type like a comma separated list instead of a strong collection like a vector of longs.

```csharp
class Vector {
    int X;
    int Y;
    int Z;
}

Vector CrossProduct(Vector factor1, Vector factor2);

// Never do this
bool CrossProduct(long x1, long y1, long z1, long x2, long y2, long z2,
                  out long resultX, out long resultY, out long resultZ);
```
*Create a strong type*

### New type idiom

The idea behind the new type idiom is to have additional type information, even if you have a single integer as an argument. Even when we have simple integers, it usually represents a concept not as generic. This concept could be years, bytes, money or position. 
So even if you have a single integer, you can create a new type from your abstract concept.

```csharp
class Years {
    Years(int years)
    {
        Value = years;
    }

    int Value { get; }
}
```
*Declaring the new type Years*

In this case we have a time period in years. The constructor should be explicit, otherwise a Year object would be automatically constructed from a given integer. That way you need to be explicit when you call a function like this:

```csharp
bool OldEnough(Years years)
```
*Use the new type*

The Function `OldEnough` only accepts years. If you give an integer or a value of type `Days` you will get a compilation error. This helps in self-documentation and avoids misunderstandings between programmers with different assumptions. The code the compiler produces is the same with or without the additional type information. The additional Type-Information is just a compile time hint for the programmer.

### Do not convert the types from the API if not necessary

Casting types can lead to unexpected behavior and should be avoided, if you need to convert types, chose a place where it minimizes the number of casts.

## Define appropriate types

If two or more items of data belong together, try to find a name for them, and define a type you can reuse. Only use Tuple when the data is generic or part of an external interface.

## Use appropriate data-structures

Do not pass around data structures as strings or tuples, when you could create a better type for your data.

## Use Readonly PODs for data

All PODs must inject their state in the constructor and provide read only properties to it.
A public setter is forbidden, a private setter is discouraged. 

## Make PODs easy to use

PODs should implement `IEquatable` or `IComparable`, use [Fody][Equals.Fody] instead of manual implementation if possible.


[Equals.Fody]: https://github.com/Fody/Equals