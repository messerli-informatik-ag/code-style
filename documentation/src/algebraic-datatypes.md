# Algebraic Datatypes

Algebraic datatypes are also called discriminated unions, tagged unions, and sometimes "or types" colloquially. 
They can be found in many functional languages (even if they're not named algebraic datatypes specifically), and have become widely known and used in Typescript 2.0.

## Algebraic datatypes in C#

While we don't have language support for algebraic datatypes in C#, there are some patterns on how you can implement something that behaves like one.

We recommend the usage of the following pattern using an abstract base class with a private constructor and inner, deriving classes and usually a match function.
This has the advantage that the algebraic options are namespaced as the inner class, which simplifies the naming.
The constructor is private to prevent extension of the algebraic datatype — with a private constructor only inner classes can derive from the abstract base class.


When your intention is to write something like an enum, but with attachable data to every option, algebraic datatypes is what you're looking for.

## Example 1 (`UpdateMode`)

Our example has three different update modes - the `ServerDefault`, the `Auto` mode via `ChannelName` and a `Version` defined `Pinned` mode.
Our match method allows us to define what should happen for each configured mode.
The upside of that over a switch expression is that we have no problems with exhaustability (see Example 2).

```csharp
public abstract class UpdateMode
{
    private UpdateMode()
    {
    }

    public abstract TResult Match<TResult>(
        Func<ServerDefault, TResult> serverDefault,
        Func<Auto, TResult> auto,
        Func<Pinned, TResult> pinned);

    public sealed class ServerDefault : UpdateMode
    {
        public override TResult Match<TResult>(
            Func<ServerDefault, TResult> serverDefault,
            Func<Auto, TResult> auto,
            Func<Pinned, TResult> pinned) 
            => serverDefault(this);
    }

    public sealed class Auto : UpdateMode
    {
        public Auto(string channelName)
        {
            ChannelName = channelName;
        }

        public string ChannelName { get; }

        public override TResult Match<TResult>(
            Func<ServerDefault, TResult> serverDefault,
            Func<Auto, TResult> auto,
            Func<Pinned, TResult> pinned) 
            => auto(this);
    }

    public sealed class Pinned : UpdateMode
    {
        public Pinned(string version)
        {
            Version = version;
        }

        public string Version { get; }

        public override TResult Match<TResult>(
            Func<ServerDefault, TResult> serverDefault,
            Func<Auto, TResult> auto,
            Func<Pinned, TResult> pinned) 
            => pinned(this);
    }
}
```

Summed up:
- Abstract class (ensures inner classes are always used in a namespaced manner, e.g. `UpdateMode.Auto`)
- Private constructor in abstract class (this ensures no one can derive from the abstract class except the inner classes)
- An abstract match method with a `Func<Variant, TResult>` for every option of the algebraic datatype
- Inner deriving sealed classes (that implement match and call the base constructor)
- You can have data either on the base class and have it passed to the base constuctor, or in the deriving classes

## Example 2 - why we recommend a match function

Consider the `UpdateMode` algebraic datatype from Example 1.

Usage example with Match:

```csharp
var info = mode.Match(
    serverDefault => $"Server default mode",
    auto => $"Auto with channel {auto.ChannelName}",
    pinned => $"Pinned to Version {pinned.Version}");
```

Usage example with switch expression:

```csharp
var info = mode switch
{
    UpdateMode.ServerDefault serverDefault => $"Server default mode",
    UpdateMode.Auto auto => $"Auto with channel {auto.ChannelName}",
    UpdateMode.Pinned pinned => $"Pinned to Version {pinned.Version}",
    _ => throw new Exception("Unreachable"), // we almost always need this, because the compiler doesn't know there's only 3 types
};
```

The advantage of using a match function is clear: 
No useless exception that is unreachable anyways, and immediate feedback from the compiler when adding another option to the algebraic datatype.

## Use lables on the match method

It is good practice to use argument labels to avoid mixups in argument order, so consider this example superior to the Match example in Example 2:

```csharp
var info = mode.Match(
    serverDefault: serverDefault => $"Server default mode",
    auto: auto => $"Auto with channel {auto.ChannelName}",
    pinned: pinned => $"Pinned to Version {pinned.Version}");
```

This is especially true if you don't need the argument itself and just execute an action:

```csharp
// This example uses ActionToUnit and NoOperation from Funcky.
// void is not a valid generic argument for a method, so we often use the Unit type for some of these use cases.
// See the Funcky documentation (https://polyadic.github.io/funcky/) for more information on the Unit type.
static void SomeMethod() => NoOperation();
mode.Match(
    serverDefault: _ => ActionToUnit(SomeMethod),
    auto: _ => ActionToUnit(SomeMethod),
    pinned: _ => ActionToUnit(SomeMethod));
```

## Disadvantages of using a match function, or why you might want your match function to be internal

When the match function is exposed from a library, adding a new variant to the algebraic datatype will break public api. 
Therefore, if you want to avoid this, you should make the match method internal. 
This makes you losing out on the exhaustiveness when the library is used, but at least you don't have to break public api to add another option.
