using System.Threading.Tasks;
using Xunit;
using VerifyCodeStyle = Messerli.CodeStyle.Analyzers.Test.CSharpVerifier<Messerli.CodeStyle.Analyzers.InterfaceAnalyzers.PublicModifier.PublicModifierInterfaceAnalyzer, Messerli.CodeStyle.Analyzers.InterfaceAnalyzers.PublicModifier.PublicModifierInterfaceCodeFix, Microsoft.CodeAnalysis.Testing.Verifiers.XUnitVerifier>;

namespace Messerli.CodeStyle.Analyzers.Test.PublicModifier
{
    public class PublicModifierInterfaceAnalyzerTest
    {
        private const string CodeToFix = @"
    public interface ITest
    {
        [|public|] void DoSomething();
    }";

        private const string FixedCode = @"
    public interface ITest
    {
        void DoSomething();
    }";

        [Fact]
        public async Task AssertsNoFixNeedsToBeApplied()
        {
            await VerifyCodeStyle.VerifyAnalyzerAsync(FixedCode);
        }

        [Fact]
        public async Task AssertsFixIsApplied()
        {
            await VerifyCodeStyle.VerifyAnalyzerAsync(CodeToFix);
        }

        [Fact]
        public async Task AssertCodeFixCreatesExpectedCode()
        {

            await VerifyCodeStyle.VerifyCodeFixAsync(CodeToFix, FixedCode);
        }
    }
}
