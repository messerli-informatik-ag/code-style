using Microsoft.CodeAnalysis;

namespace Messerli.CodeStyle.Analyzers.InterfaceAnalyzers.PublicModifier
{
    public static class RuleConstants
    {
        private static readonly LocalizableString Title = "Interface method declaration contains public access modifiers";
        private static readonly LocalizableString MessageFormat = "Method contains public access modifiers";
        private static readonly LocalizableString Description = "Public access modifiers should all be omitted on interface method declaration.";
        private const string Category = "Access Modifiers";

        public const string DiagnosticId = "MESSERLI001";

        public static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(
            id: DiagnosticId,
            title: Title,
            messageFormat: MessageFormat,
            category: Category,
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: Description);
    }
}
