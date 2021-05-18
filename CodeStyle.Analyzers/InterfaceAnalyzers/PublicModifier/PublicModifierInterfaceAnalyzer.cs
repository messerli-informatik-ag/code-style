using System;
using System.Collections.Immutable;
using Funcky.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Messerli.CodeStyle.Analyzers.InterfaceAnalyzers.PublicModifier
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class PublicModifierInterfaceAnalyzer : DiagnosticAnalyzer
    {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(RuleConstants.Rule);

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
            context.EnableConcurrentExecution();
            context.RegisterSyntaxNodeAction(AnalyzeInterfaceMethods, SyntaxKind.MethodDeclaration);
        }

        private static void AnalyzeInterfaceMethods(SyntaxNodeAnalysisContext context)
        {
            var node = (BaseMethodDeclarationSyntax)context.Node;
            if (node.Parent.IsKind(SyntaxKind.InterfaceDeclaration))
            {
                HandleDefaultModifier(context, node.Modifiers, SyntaxKind.PublicKeyword);
            }
        }

        private static void HandleDefaultModifier(SyntaxNodeAnalysisContext context, SyntaxTokenList modifiers, SyntaxKind defaultModifier)
        {
            modifiers.FirstOrNone(item => item.IsKind(defaultModifier))
                .AndThen(ReportDiagnostic(context));
        }

        private static Action<SyntaxToken> ReportDiagnostic(SyntaxNodeAnalysisContext context)
            => token
                => context.ReportDiagnostic(Diagnostic.Create(RuleConstants.Rule, token.GetLocation()));
    }
}
