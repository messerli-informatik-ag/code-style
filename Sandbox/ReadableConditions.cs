using System;

namespace Sandbox
{
    public static class ReadableConditions
    {
        public static void Conditions()
        {
            if (10 == Environment.ExitCode)
            {
            }

            if (10 <= Environment.ExitCode && Environment.ExitCode > 20)
            {
            }
        }
    }
}
