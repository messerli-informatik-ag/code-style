using System.Collections.Generic;
using System.Linq;

namespace Sandbox
{
    public static class UnnecessaryParenthesis
    {
        public static IEnumerable<int> ExpressionWithUnnecessaryParenthesis()
            => (from x in Enumerable.Repeat(1, 1)
                from y in Enumerable.Repeat(2, 1)
                select x + y);
    }
}
