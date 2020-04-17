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

[IDisposableAnalyzers Changelog]: https://github.com/DotNetAnalyzers/IDisposableAnalyzers/blob/master/RELEASE_NOTES.md

## Unreleased
- Enable `GenerateDocumentationFile` by default. This had to be turned on manually in each project before,
  as it is required by our StyleCop configuration.
