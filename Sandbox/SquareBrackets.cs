using System.Collections.Generic;

namespace Sandbox;

public sealed class SquareBrackets
{
    public IReadOnlyCollection<int> Ints => [1, 2, 3];

    public IReadOnlyCollection<int> IntsFunc(bool pred)
        => pred
            ? [1, 2, 3]
            : [2, 3, 4];
}
