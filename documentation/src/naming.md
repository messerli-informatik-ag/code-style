# Naming Conventions

Names should be descriptive; avoid abbreviations.
Give a descriptive name, but be specific. Do not worry about saving horizontal space, as it is far more important to make your code immediately understandable by a new reader. We do not contract words or make up words.

## We use English words for abstractions

* The programming language is in English, most concepts are in English, therefore English is a lot easier to make consistent. (WriteExportAbacusEinFile, etc.)
* Most of the concepts except a few in the building industry are already in English.
* We want to avoid being confused about GetProject vs GetProjekt. For a single concept, only one word in one language should be chosen.
* Avoid variables like workWork (sic)
* It is a lot easier to create plurals in English (-s, -ies) where in German it might be difficult: Kapitel, Mitarbeiter, Unternehmer, Fenster, Artikel (see also next point)
* Proper Nouns  should not be translated even if possible.
* We try to use the same word for the same abstraction. It is either a project or a tenant. (DDD)
* All widely used concepts should be listed in the glossary

## Be specific

<figure>
    <img src="./images/oop-naming.png" alt="The world seen by an &quot;object-oriented&quot; programmer." />
    <figcaption>!DDD</figcaption>
</figure>

Only use generic words like, data, list, string, number, manager, gateway and handler if necessary in a generic context. Otherwise, try to find specific domain words. Build a domain specific ubiquitous language.
In domain context, always use the domain vocabulary and try keeping the overhead to a minimum, be precise.

## Abbrevations
We do not use abbreviations that are ambiguous or unfamiliar to readers outside our project, and we do not abbreviate by skipping letters within a word. Abbreviations that would be familiar to someone outside your project with relevant domain knowledge are OK. As a rule of thumb, an abbreviation is probably OK if it is listed in Wikipedia like IP or HTML.
All abbreviations are written in PascalCase.

```csharp
class JsonToHtmlConverter {}
class IpAddress {}
class UserId {}
class TfsConnector {}
```
*Abbrevation Examples*

## Use plural and singular to your advantage

If you have a collection of things, use the plural form of the variable you would use for a single element. Prefer being specific, as the name of the collection should reflect the meaning behind its elements. This gives you a natural understanding on what object you are dealing with.

```csharp
var onlineUsers = GetOnlineUsers();
for (var user in onlineUsers) {
    user.GoOffline();
}
```
*Correct usage of plural*

## Try to use the same word for the same concept

Do not switch between different name for a concept, make a choice and stick to it.

## Naming the different C# identifiers

Table following table gives you the rules for each identifier.

| Identifier                | Casing                                 | Prefix / Suffix                                 | Example                  |
|---------------------------|----------------------------------------|-------------------------------------------------|--------------------------|
| Namespace                 | PascalCase                             |                                                 | Messerli\.Core           |
| Class                     | PascalCase                             |                                                 | WarpEngine               |
| Exception class           | PascalCase                             | \<Name>Exception                                | InvalidArgumentException |
| Interface                 | PascalCase                             | I\<Name>                                        | ISyntaxTree              |
| Abstract class            | PascalCase                             |                                                 | Application              |
| Method                    | PascalCase                             |                                                 | DrawSquare               |
| Properties                | PascalCase                             |                                                 | FirstName                |
| Predicate method          | PascalCase                             | Is\<Name\>, Has\<Name>, Are\<Name>, Have\<Name> | IsGreat, HasField        |
| Public Member Variable    | PascalCase                             |                                                 | Diameter                 |
| Protected member variable | camelCase                              | _\<name>                                        | _tableIndex              |
| Private member variable   | camelCase                              | _\<name>                                        | _adjacencyMatrix         |
| Local variable            | camelCase                              |                                                 | index, name, helpLabel   |
| Global constant           | PascalCase                             |                                                 | Pi, PrimeNumbers         |
| Class constant            | PascalCase                             |                                                 | FilePath                 |
| Enum type                 | PascalCase                             |                                                 | StatusType               |
| Enum value                | PascalCase                             |                                                 | RequiredValue            |
| Lambda Parametrs          | camelCase or lower-case letter         |                                                 | cornerPoint, c, name, n  |


## UI Elements
When dealing with UI Elements like buttons, combo boxes, grids, text boxes, etc. we append the full name of the type without any prefix to the variable name. 

```csharp
class UserRightDialog {
    Grid _userGrid;
    Edit _userNameEdit;
    Button _okButton;
};
```
*Naming of UI Elements*

## Naming of delegate variables

All delegate variables should be in camelCase without a prefix or postfix. All other Methods are PascalCase which means if you see a createThing(), you will know that it is indeed a delegate call.

## Naming of Tests

The naming of tests must describe what the intended effect of the methods that are being tested, e.g. `ReturnsNullOnEmptySettings` or `ThrowsOnInvalidResponse`.