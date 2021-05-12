using Microsoft.CodeAnalysis;
using static Messerli.CodeStyle.Analyzers.InterfaceAnalyzers.PublicModifier.ConstantsProperties;

namespace Messerli.CodeStyle.Analyzers.InterfaceAnalyzers.PublicModifier
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
