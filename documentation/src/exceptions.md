# Exceptions

Exceptions are a good tool to signal behavior out of the ordinary.

## Use Nullable (`?`) types if you need to represent values with a no-value state

Do not use bools to indicate illegal state, as they can easily be ignored. Wrapping a returned type in an nullable value forces the caller to check for the state. Ideally use them in a monadic way with an appropriate library.

## Do not use exceptions for control flow

Exceptions should be used to signal exceptional behavior, such as incorrect user input or missing resources. Using them for (expected) control flow is analogous to using a goto statement.
