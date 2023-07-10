# Messerli Code Style

![Build](https://github.com/messerli-informatik-ag/code-style/workflows/Build/badge.svg)
[![NuGet](https://img.shields.io/nuget/v/Messerli.CodeStyle.svg)](https://www.nuget.org/packages/Messerli.CodeStyle)
[![Coding Guidelines](https://img.shields.io/badge/coding%20guidelines-website-blueviolet)](https://messerli-informatik-ag.github.io/code-style/)

## Usage

Add the following package reference to your project or to your `Directory.Build.props`:
```diff
  <?xml version="1.0" encoding="utf-8"?>
  <Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
+     <ItemGroup>
+         <PackageReference Include="Messerli.CodeStyle" PrivateAssets="all" />
+     </ItemGroup>
  </Project>
```

You either have to add the version here or in `Directory.Packages.props` depending on if you're using [Central Package Management](https://learn.microsoft.com/en-us/nuget/consume-packages/Central-Package-Management).

## Warnings as Errors

Some analyzer rules, such as rules involving single line comments, are configured as warnings to facilitate development.
To enforce these rules, enable `TreatWarningsAsErrors` for CI builds.

```diff
- dotnet build --no-restore
+ dotnet build --no-restore /p:TreatWarningsAsErrors=true
```

### Github Actions
```diff
 jobs:
   build:
     steps:
     # ...
     - name: Build
-      run: dotnet build --no-restore
+      run: dotnet build --no-restore /p:TreatWarningsAsErrors=true
     # ...
```

### Azure Devops
```diff
 steps:
 # ...
 - task: DotNetCoreCLI@2
   displayName: Build
   inputs:
-    arguments: '--no-restore'
+    arguments: '--no-restore /p:TreatWarningsAsErrors=true'
 # ...
```
