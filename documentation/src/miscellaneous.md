# Miscellaneous

## Use the Humble Object Pattern for System boundaries like UI

At the boundaries of the system, where things are often difficult to test use the humble object pattern to make it better testable. We accomplish the pattern by reducing the logic close to the boundary, making the code close to the boundary so humble that it doesn't need to be tested. The extracted logic is moved into another class, decoupled from the boundary which makes it testable.

## Use the type system

Unit tests became extremely popular with dynamically typed languages like Ruby and JavaScript out of necessity. Those languages became popular initially for relatively small code fragments for automation or simple tasks. They were not designed as system languages with millions of lines of code in mind. But these languages became popular and the ecosystem grew and therefore also the need for refactoring in bigger projects. Since the type system were weak the compiler or run-time could not help much in finding defects. 
Unit tests do much more than just checking if the types are in the expected range, and if a function is correctly typed, but it is one kind of unit tests we do not need in statically typed languages. However it is important that you actually use the type System to your advantage.

## Avoid regions

Regions can distract and hide things from you, that is why regions are generally discouraged except for automatically generated code, you wouldn't want to change by hand.
