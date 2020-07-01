# Object oriented programming

## Abstraction

### Depend on abstractions not implementations

Classes which are not PODs must depend on abstractions and not implementations if possible.

### Create your own abstractions if none are available

If the library you are using do not offer their own abstractions, create a facade with your own abstractions in front of the implementation.

### Factories

Avoid the usage of new, either inject types through the constructor or use factories to create objects on runtime. All Factories should be declared via a delegate in the form of:

```csharp
public delegate ReturnValue ReturnValueFactory(Parameters parameters)
```
*Signature of factories*

## Inheritance

* If the relation between two entities can be described as a "Entity A has B"-relation then composition is to be used. You should only use inheritance if you are dealing with a "Entity A is a kind of B"-relation. See: Composition over inheritance.
* Prefer inheriting from interfaces
* Keep your inheritance hierarchy flat
  * avoid abstract classes

## Encapsulation

### Data-Members are by default private

Classes are meant to hide the implementation details; this also means that your data should be hidden from the outside. If you really need public data-members, you might want to think about separating the data into a POD class.

### Use the most restricitive visibility modifier possible

Information should be encapsulated as much as possible, which means in first instance it should be private.

### public fields are forbidden

We only use properties for public interfaces for PODs and other classes.

## Polymorphism

### Use the strategy Pattern for different implementations of the same algorithm

The strategy pattern embodies two core principles of object-oriented programming, it encapsulates the concept that varies and lets programmers code to an interface, not an implementation.

### Use the different forms of polymorphism to your advantage

C# supports runtime subtype polymorphism with virtual Methods, but there are other forms of polymorphism in C#.

The other form is the ability to overload methods with different parameter types which is a form of static compile time polymorphism. It is more powerful in the regard that you can overload on any type and you do not need to have a type hierarchy for it to work. However be careful on this, the overload resolution uses the static type-definition and not the run-type type definition. Which means this is limited to cases where you exactly know the type at compile time.

### Use the visitor pattern for double dispatch

[Static overload resolution can dispatch on more than one type][multiple-dispatch], but at runtime we are limited to a single dispatch mechanism offered by the subtype polymorphism. To overcome this, we need to take advantage of both forms of polymorphism offered in C#. The visitor pattern is the right choice in such cases.

[multiple-dispatch]: https://eli.thegreenplace.net/2016/a-polyglots-guide-to-multiple-dispatch