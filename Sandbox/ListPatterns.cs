using System;

namespace Sandbox;

public static class ListPatterns
{
    public static void Patterns()
    {
        var firstFivePrimes = new[] { 2, 3, 5, 7, 11 };
        if (firstFivePrimes is [_, var second, ..])
        {
            Console.WriteLine($"Second prime is {second}");
        }
    }
}
