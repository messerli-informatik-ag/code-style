# Changelog

## 1.0.0-alpha.1
Initial release

## 1.0.0
- Add support for netstandard2.0.
- Add support for projects that target multiple frameworks.

## 1.0.1
- Hide stylecop.json in Visual Studio.

## 1.1.0
- Update IDisposableAnalyzers from 3.2.0 to 3.3.2. Excerpt from [IDisposableAnalyzers Changelog]:
  > #### 3.3.0
  > - FEATURE: Initial support for AsyncDisposable

## 1.2.0
- Disable SA1412 (StoreFilesAsUtf). This means that BOMs are no longer required in C# files.
- Update IDisposableAnalyzers from 3.3.2 to 3.3.8:
- Update StyleCop.Analyzers from 1.2.0-beta.113 to 1.2.0-beta.164 ([diff](https://github.com/DotNetAnalyzers/StyleCopAnalyzers/compare/1.2.0-beta.113...1.2.0-beta.164)).
- Enable `GenerateDocumentationFile` by default. This had to be turned on manually in each project before,
  as it is required by our StyleCop configuration.

## 1.2.1
- Update StyleCop.Analyzers to 1.2.0-beta.205. ([diff](https://github.com/DotNetAnalyzers/StyleCopAnalyzers/compare/1.2.0-beta.164...1.2.0-beta.205))
- Update IDisposableAnalyzers to 3.4.1. Excerpt from [IDisposableAnalyzers Changelog]:
  > #### 3.4.1
  > * Publish with binaries.
  > #### 3.4.0
  > * FEATURE: Handle DisposableMixins.DisposeWith
  > * BUGFIX: IDISP025 when abstract dispose method.
  > * BUGFIX: IDISP006 when explicit implementation.

## 2.0.0-rc.1
* Breaking: Treat all nullability warnings as errors.
* Lints involving single line comments have been reduced to warnings to make temporary code commenting easier.
* The hungarian notation rule has been relaxed to allow `js` and `db` since those two are common "false positives".

## 2.0.0-rc.2
- Update StyleCop.Analyzers to 1.2.0-beta.261. ([diff](https://github.com/DotNetAnalyzers/StyleCopAnalyzers/compare/1.2.0-beta.205...1.2.0-beta.261))

## 2.0.0-rc.3
- Update StyleCop.Analyzers to 1.2.0-beta.312 ([diff](https://github.com/DotNetAnalyzers/StyleCopAnalyzers/compare/1.2.0-beta.261...1.2.0-beta.312))
- Fix compilation error when building an F# project.

## 2.0.0
* Update IDisposableAnalyzers to 3.4.8. Excerpt from [IDisposableAnalyzers Changelog]:
  > #### 3.4.8
  >  * BUGFIX: Don't use Roslyn's SymbolEqualityComparer
  > #### 3.4.7
  >  * Can't repro issues, thinking maybe the 3.4.6 release used wrong binaries.
  > #### 3.4.6
  > * BUGFIX: IDSP007 when using declaration.
  > * BUGFIX: Figure out chained calls.
  > #### 3.4.5
  > * FEATURE: Handle switch expression.
  > * BUGFIX: Figure out await in more places.
  > * BUGFIX: Tweak assumptions about binary symbols.
  > * BUGFIX: Handle Interlocked.Exchange
  > #### 3.4.4
  > * FEATURE: Handle some common uses of reflection.
  > #### 3.4.3
  > * Special case ConnectionFactory.CreateConnection
  > * BUGFIX: Handle chained calls
  > * BUGFIX: Cast and dispose correctly.
  > #### 3.4.2
  > * Handle some regressions in Roslyn 3.7
* Update StyleCop.Analyzers to 1.2.0-beta.321 ([diff](https://github.com/DotNetAnalyzers/StyleCopAnalyzers/compare/1.2.0-beta.312...1.2.0-beta.321)) \
  Notable changes/fixes:
  * [9c5c071: Support records without braces](https://github.com/DotNetAnalyzers/StyleCopAnalyzers/compare/1.2.0-beta.312...1.2.0-beta.321)
  * [46d2e37: Support implicit object creation expressions in SA1129 code fix](https://github.com/DotNetAnalyzers/StyleCopAnalyzers/commit/46d2e37fed1e471446f32c88c6bdaf2530239570)

## 2.0.1
* Update IDisposableAnalyzers to 3.4.13. Excerpt from [IDisposableAnalyzers Changelog]:
  > #### 3.4.13
  > * BUGFIX: Specialcase Gu.Reactive extension methods.
  > #### 3.4.12
  > * BUGFIX: When leaveOpen has default value
  > #### 3.4.11
  > * BUGFIX IDISP023 handle trivial and.
  > * BUGFIX IDISP023 when chained constructors
  > * BUGFIX IDISP001 when if statement.
  > * BUGFIX IDISP004 when chained leave open.
  > #### 3.4.10
  > * BUGFIX: Handle using in loop
  > #### 3.4.9
  > * BUGFIX: IDISP023 Allow touching static reference types.
  > * BUGFIX: AD0001: Analyzer 'IDisposableAnalyzers.LocalDeclarationAnalyzer
* Update StyleCop.Analyzers to 1.2.0-beta.333 ([diff](https://github.com/DotNetAnalyzers/StyleCopAnalyzers/compare/1.2.0-beta.321...1.2.0-beta.333)) \
  Notable changes/fixes:
  * [23db6c0: Avoid reporting SA1141 (Use tuple syntax) in expression trees](https://github.com/DotNetAnalyzers/StyleCopAnalyzers/commit/af356f9b36dc4849a678c0b8c918123fa567913b)

## 2.1.0
* Warn when interface method has `public` accessibility modifier (`MESSERLI001`)

## Unreleased
* Relaxed rules:
  * [SA1119](https://github.com/DotNetAnalyzers/StyleCopAnalyzers/blob/master/documentation/SA1119.md) (StatementMustNotUseUnnecessaryParenthesis) is now disabled.

* Update IDisposableAnalyzers to 3.4.15. Excerpt from [IDisposableAnalyzers Changelog]:
  > #### 3.4.15
  > * BUGFIX: IDISP005 with ServiceDescriptor
  > * BUGFIX: IDISP004 when DisposeWith
  > #### 3.4.14
  > * BUGFIX: IDISP005 should not warn in Assert.Throws.
  > * BUGFIX: Handle function pointer.
  > #### 3.4.13
  > * BUGFIX: Specialcase Gu.Reactive extension methods.


[IDisposableAnalyzers Changelog]: https://github.com/DotNetAnalyzers/IDisposableAnalyzers/blob/master/RELEASE_NOTES.md
