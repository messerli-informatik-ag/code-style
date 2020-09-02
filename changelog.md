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

[IDisposableAnalyzers Changelog]: https://github.com/DotNetAnalyzers/IDisposableAnalyzers/blob/master/RELEASE_NOTES.md

## Unreleased
* Breaking: Treat all nullability warnings as errors.
* Lints involving single line comments have been reduced to warnings to make temporary code commenting easier.
* The hungarian rule has been relaxed to allow `js` and `db` since those two are common "false positives".