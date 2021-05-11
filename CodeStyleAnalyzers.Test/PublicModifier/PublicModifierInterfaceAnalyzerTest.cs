using System.Threading.Tasks;
using Xunit;
using VerifyCodeStyle = CodeStyleAnalyzers.Test.CSharpVerifier<CodeStyleAnalyzers.InterfaceAnalyzers.PublicModifier.PublicModifierInterfaceAnalyzer, CodeStyleAnalyzers.InterfaceAnalyzers.PublicModifier.PublicModifierInterfaceCodeFix, Microsoft.CodeAnalysis.Testing.Verifiers.XUnitVerifier>;

namespace CodeStyleAnalyzers.Test.PublicModifier
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
