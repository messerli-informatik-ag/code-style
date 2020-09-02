# Messerli Code Style

![Build](https://github.com/messerli-informatik-ag/code-style/workflows/Build/badge.svg)
[![NuGet](https://img.shields.io/nuget/v/Messerli.CodeStyle.svg)](https://www.nuget.org/packages/Messerli.CodeStyle)
[![Coding Guidelines](https://img.shields.io/badge/coding%20guidelines-website-blueviolet)](https://messerli-informatik-ag.github.io/code-style/)

## Usage

### Without the CentralPackageVersions SDK

Add the following package reference to your project or to your `Directory.Build.props`:

```diff
  <?xml version="1.0" encoding="utf-8"?>
  <Project>
      <ItemGroup>
+         <PackageReference Include="Messerli.CodeStyle" Version="1.2.0" PrivateAssets="all" />
      </ItemGroup>
  </Project>
```

### With the CentralPackageVersions SDK

Add `Messerli.CodeStyle` to your `Packages.props`:
```diff
  <?xml version="1.0" encoding="utf-8"?>
  <Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
      <ItemGroup Label="Build dependencies">
+         <PackageReference Update="Messerli.CodeStyle" Version="1.2.0" />
      </ItemGroup>
  </Project>
```

Add the following package reference to your project or to your `Directory.Build.props`:
```diff
  <?xml version="1.0" encoding="utf-8"?>
  <Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
+     <ItemGroup>
+         <PackageReference Include="Messerli.CodeStyle" PrivateAssets="all" />
+     </ItemGroup>
  </Project>
```
```


