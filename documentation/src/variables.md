# Variables

## Only one declaration per line

Multiple declarations per line are not allowed. This way, we can reduce the mental baggage of the reader and avoid awkward pointer and reference declarations (See the next subchapter).
Deconstruction of Tuples and other types are obviously exempt from this rule. 

```csharp
var (name, address, city, zip) = contact.GetAddressInfo();
```
*Example: tuple deconstruction*

## Local variables have good names

Local variables should have self-evident names too. Every variable should describe its content, and named consistently. One can often reuse the name of the type. Be as specific as necessary and as short as possible.

## Declare variables in the innermost scope that is possible

This rule attempts to minimize the number of live variables that must be simultaneously considered. Furthermore, variable declarations should be postponed until enough information is available for full initialization. This rule also reduces the possibility of uninitialized and wrongly initialized variables.

## Define variables on declaration

Local variables of primitive type are not initialized. Try to avoid separation of declaration and definition.

```csharp
// Do not write this!
Money money;
money = GetMoney();
```
*Bad example*

```csharp
Money money = GetMoney();
```
*Better example*

```csharp
var money = GetMoney();
```
*Even better example*

This can lead to problems if your variable is initialized differently on a certain condition (`if`/`switch`). Prefer the use of `if`-expressions with the the ternary operator (? :) for simple cases or extract the initialization into a function

```csharp
var money = HasBank() 
    ? GetFromBank() 
    : GetCash();
```
*This could also be easily refactored into a function*

This not only avoids uninitialized variables, but makes sure you always handle both cases.

With C# 8.0 switch-expressions are introduced which are highly recommended instead of switch-statements.

## Do not reuse variables

A variable should have only one single purpose; there is no reason to recycle variables. The variables are abstractions for the human reader and not memory locations for the compiler.

## Prefer type inference

Use var to avoid type names, especially those that are noisy, obvious, or unimportant — cases where the type does not aid in clarity for the reader. Only use manifest type declarations when it helps readability.

```csharp
var textBox = GetTextBox();
textBox.SetText("foo");
```
*Type inference*

This does not mean that you should blindly replace types with var.

## Do not use magic values

Every number except 0 or 1 needs a useful name derived from its true meaning in the code. However, this does not mean that 0 and 1 cannot have a name too.
The same goes for magic strings!

## Unused variables with discared values

Ideally we would prefer a clean way with pattern matching, where we always could use `_`. Since this is only possible in certain parts of the language, we still try to use the `_` for unused variables. If you have more than one unused variable in the same context, use `_0`, `_1`, … instead.
