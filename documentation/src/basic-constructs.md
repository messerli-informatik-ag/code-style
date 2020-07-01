# Basic constructs

## Only one expression per line

Multiple expressions or statements in one line increase the mental burden while reading them. Split them up to avoid mentally hiding statements.

## Prefer logical operators to if statements

```csharp
if (node.GetParenthesis(key)) {
    item.Setting = false;
} else {
    item.Setting = true;
}
```
*Avoid if and ternary operator for logical expressions*

Logical expressions have no branches, are more concise and always handle all the logical cases.

```csharp
item.Setting = !GetParenthesis(key);
```
*Use logical operators `!`, `&&` and `||`*


## If-statements

The condition of the if-statement should have no side effects.
Avoid nested if-statements and prefer logical operators.

```csharp
if (!Move(id)) {
    return false;
}

if (!UpdateStart(StartValue)) {
    return false;
}
```
*Avoid side-effects*

```csharp
var itemFound = Move(id);
if (!itemFound) {
    return false;
}

var updateIsReady = UpdateStart(StateDelete);
if (!updateIsReady) {
    return false;
}
```
*Better alternative*

## ternary operator

Prefer the ternary operator to simple if statements. The ternary operator is an expression in contrast to the if-statement and it forces you to handle all the cases.

We format the ternary operator like this, to see which branch we are dealing with easily.

```csharp
return condition
    ? true-expression
    : false-expression;
```
*ternary operator*

## Expression-bodied members

Use the expression body syntax when a member returns a single expression.
Move the arrow to the next line when the expression gets too long.

```csharp
public int Length => 0;

public string AbsolutePath()
    => Path.Combine(CalculateRootPath(), RelativePath);
```
*expression-bodied members*

## For-loops

Avoid for-loops and use LINQ and higher order functions as an alternative.

## Prefer foreach-loops

Whenever you are iterating over some kind of enumerator, prefer the foreach syntax:

```csharp
foreach (var value in values.OrderByDescending(v => v)) {
    // Do something in reverse order
}
```
*foreach-loop*

## Switch-statement

### Handle all cases

Unhandled cases lead the program into an undefined state. If you have no natural default case, declare one throwing a System.NotImplementedException.

## Goto

The goto statement is forbidden in all cases.