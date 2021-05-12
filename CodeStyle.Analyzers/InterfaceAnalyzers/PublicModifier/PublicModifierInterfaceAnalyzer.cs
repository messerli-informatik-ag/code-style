using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace CodeStyle.Analyzers.InterfaceAnalyzers.PublicModifier
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class PublicModifierInterfaceAnalyzer : DiagnosticAnalyzer
    {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(RuleConstants.Rule);

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.ReportDiagnostics);
            context.EnableConcurrentExecution();
            context.RegisterSyntaxNodeAction(AnalyzeInterfaceMethods, SyntaxKind.MethodDeclaration);
        }

        private void AnalyzeInterfaceMethods(SyntaxNodeAnalysisContext context)
        {
            var node = (BaseMethodDeclarationSyntax)context.Node;
            if (node.Parent.IsKind(SyntaxKind.InterfaceDeclaration))
            {
                HandleDefaultModifier(context, node.Modifiers, SyntaxKind.PublicKeyword);
            }
        }

        private void HandleDefaultModifier(SyntaxNodeAnalysisContext context, SyntaxTokenList modifiers, SyntaxKind defaultModifier)
        {
            var index = modifiers.IndexOf(defaultModifier);
            if (index != -1)
            {
                context.ReportDiagnostic(Diagnostic.Create(RuleConstants.Rule, modifiers[index].GetLocation()));
            }
        }
    }
}
