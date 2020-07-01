# Comments

Though a pain to write, comments are vital to keeping our code readable. The following rules describe what you should comment and where. However, remember: while comments are very important, the best code is self-documenting. Giving sensible names to types and variables is much better than using obscure names that you must then explain through comments.
When writing your comments, write for your audience. The next contributor who will need to understand your code. Be generous - the next one may be you!

## Language

Comments are written in English.

## Style

We only use double and triple-slash comments. We do not use the /* */ - style comments.
Write your comments above your code you want to comment. Only write comments on the right side of the code when doing so would benefit the readability greatly and the code in question is very short, e.g. an initialization.
If your code describes a block of code, consider refactoring it into a function.

## XML comments

Try to document your public interface. 

* The comments for an interface should be only in the header file.
* Try avoiding stating the obvious.
* We use XML-comments to document the interface.

```csharp
/// <summary>
/// Specifies that <see cref="Open"/> should open an existing file.
/// When the file is opened, it should be truncated so that its size is zero bytes.
/// Requires that <see cref="Write"/> is called too.
/// Can not be used to together with <see cref="Append"/>.
/// </summary>
IFileOpeningBuilder Truncate(bool truncate = true);
```
*Commenting a function*

We want to adhere closely to this style because Visual Studio can read and interpret the XML comments, and IntelliSense will give you a real-time information on ctrl-space. As you can see, you do not only get the general summary, but a value-by-value reference of the parameters.

## Write useful comments

A comment is useful, if it helps to understand the code better than without. Comments are not useful if they state the obvious or are repeating what the code already tells you.
Comments are especially useful if you do something out of the ordinary, or complex. A high-level description of an algorithm for example is usually a good idea.

## ASCII Art seperators are forbidden in code

For visual seperation you can use a #pragma region declaration.

A region can be folded for increased visibility:

<figure>
    <img src="./images/pragma-region-open.png" />
    <figcaption>Define a region</figcaption>
</figure>

<figure>
    <img src="./images/pragma-region-closed.png" />
    <figcaption>Region folded</figcaption>
</figure>
    
## Comments on curly brace

There are no comments on the ending curly brace. Your IDE can do code folding

<figure>
    <img src="./images/code-folding-open.png" />
    <figcaption>Function not folded</figcaption>
</figure>

<figure>
    <img src="./images/code-folding-closed.png" />
    <figcaption>Function folded</figcaption>
</figure>


## Do not commit code that is commented out

Code that is not compiled will rot and will be useless soon. If you really need the code, why is it not compiled? Delete the code. If you really need it again, you can always use your source control system.
