using Microsoft.CodeAnalysis;

namespace Messerli.CodeStyle.Analyzers.InterfaceAnalyzers.PublicModifier
{
    internal static class ConstantsProperties
    {
        public static readonly LocalizableString Title = "Interface method declaration contains public access modifiers.";
        public static readonly LocalizableString MessageFormat = "Method contains public access modifiers.";
        public static readonly LocalizableString Description = "Public access modifiers should all be omitted on interface method declaration.";
        public const string Category = "Access Modifiers";
    }
}
