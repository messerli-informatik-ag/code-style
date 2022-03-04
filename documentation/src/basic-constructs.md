# Basic constructs

## Only one expression per line

Multiple expressions or statements in one line increase the mental burden while reading them. Split them up to avoid mentally hiding statements.

## If-statements

The condition of the if-statement should have no side effects.
Avoid nested if-statements and prefer logical operators.

```csharp
if (!Move(id))
{
    return false;
}

if (!UpdateStart(StartValue))
{
    return false;
}
```
*Avoid side-effects*

```csharp
var itemFound = Move(id);
if (!itemFound)
{
    return false;
}

var updateIsReady = UpdateStart(StateDelete);
if (!updateIsReady)
{
    return false;
}
```
*Better alternative*

## For-loops

Avoid for-loops and use LINQ and higher order functions as an alternative.

## Prefer foreach-loops

Whenever you are iterating over some kind of enumerator, prefer the foreach syntax:

```csharp
foreach (var value in values.OrderByDescending(v => v))
{
    // Do something in reverse order
}
```
*foreach-loop*

## Switch-statement

### Handle all cases
Unhandled cases lead the program into an undefined state.
If you have no natural default case, declare one throwing an [`ArgumentException`] when dealing with an argument or an [`InvalidOperationException`] for all other cases.

## Goto
The goto statement is forbidden in all cases.


[`ArgumentException`]: https://docs.microsoft.com/en-us/dotnet/api/system.argumentexception
[`InvalidOperationException`]: https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception
