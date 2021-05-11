using Microsoft.CodeAnalysis;
using static CodeStyleAnalyzers.InterfaceAnalyzers.PublicModifier.ConstantsProperties;

namespace CodeStyleAnalyzers.InterfaceAnalyzers.PublicModifier
{
    public static class RuleConstants
    {
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
