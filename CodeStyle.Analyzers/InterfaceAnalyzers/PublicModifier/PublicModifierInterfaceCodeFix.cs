using System;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Editing;

namespace Messerli.CodeStyle.Analyzers.InterfaceAnalyzers.PublicModifier
{
    [ExportCodeFixProvider(LanguageNames.CSharp)]
    public class PublicModifierInterfaceCodeFix : CodeFixProvider
    {
        private static readonly string CodeFixTitle = "Remove unnecessary access modifier";

        public sealed override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(RuleConstants.DiagnosticId);

        public sealed override FixAllProvider GetFixAllProvider() => WellKnownFixAllProviders.BatchFixer;

        public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);

            var diagnostic = context.Diagnostics.First();
            var diagnosticSpan = diagnostic.Location.SourceSpan;

            var syntaxToken = root.FindToken(diagnosticSpan.Start);

            context.RegisterCodeFix(
                CodeAction.Create(
                    title: CodeFixTitle,
                    createChangedDocument: cancellationToken => FixCode(context.Document, syntaxToken, cancellationToken),
                    equivalenceKey: CodeFixTitle),
                diagnostic);
        }

        private static async Task<Document> FixCode(Document document, SyntaxToken syntax, CancellationToken cancellationToken)
        {
            var editor = await DocumentEditor.CreateAsync(document, cancellationToken).ConfigureAwait(false);
            var nextToken = syntax.GetNextToken();
            editor.ReplaceNode(
                syntax.Parent,
                syntax.Parent.ReplaceTokens(new[] { syntax, nextToken },
                    (current, _) => ExtractSyntaxToken(syntax, current, nextToken)));
            return editor.GetChangedDocument();
        }

        private static SyntaxToken ExtractSyntaxToken(SyntaxToken syntax, SyntaxToken current, SyntaxToken next)
            => current switch
            {
                _ when current == syntax => SyntaxFactory.Token(SyntaxKind.None),
                _ when current == next => next.WithLeadingTrivia(syntax.LeadingTrivia.AddRange(next.LeadingTrivia)),
                _ => throw new ArgumentOutOfRangeException(nameof(current), current, null)
            };
    }
}
