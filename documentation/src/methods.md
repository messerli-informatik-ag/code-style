# Methods

## Usually keep a method signature on one line

Alternativly get each parameter on a single line, especially for constructors where the injected objects can change often.

```csharp
void Signature(int foo, string bar);
```
*Function signature*

## Write short methods

Prefer small and focused functions.
We recognize that long functions are sometimes appropriate, so no hard limit is placed on functions length. If a function exceeds about 30 lines, think about whether it can be broken up without harming the structure of the program.
Even if your long function works perfectly now, someone modifying it in a few months may add new behavior. This could result in bugs that are hard to find. Keeping your functions short and simple makes it easier for other people to read and modify your code.
You could find long and complicated functions when working with some code. Do not be intimidated by modifying existing code: if working with such a function proves to be difficult, you find that errors are hard to debug, or you want to use a piece of it in several different contexts, consider breaking up the function into smaller and more manageable pieces.

## Output parameters

Output parameters are forbidden. They are bad style and not necessary. Return multiple values as a tuple or your own better datastructure.

```csharp
(ReceiverChannel, SendingChannel) CreateChannels();
var (rx, tx) = CreateChannels();
```
*Multiple return values*

## Ref parameters

Ref parameters are forbidden in our own API.