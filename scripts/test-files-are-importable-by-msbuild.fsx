#r "nuget: Messerli.TempDirectory,0.3.0"

open System.Diagnostics
open System.IO
open System.IO.Compression
open Messerli.TempDirectory

let ensureSuccessExitCode(p: Process) =
    if p.ExitCode <> 0 then
        raise (IOException($"The process {p.StartInfo.FileName} exited with a non-zero exit code {p.ExitCode}"))

let addArguments (info: ProcessStartInfo) args =
    args |> Seq.iter info.ArgumentList.Add

let runProcess filename args =
    let formattedArgs = args |> String.concat " "
    printfn $"+ {filename} {formattedArgs}"
    let startInfo = ProcessStartInfo(filename)
    addArguments startInfo args
    use p = Process.Start(startInfo)
    p.WaitForExit()
    ensureSuccessExitCode p

let buildNuGetPackages outputDirectory =
    Directory.CreateDirectory(outputDirectory) |> ignore
    runProcess "dotnet" ["pack"; "CodeStyle/CodeStyle.csproj"; $"/p:PackageOutputPath={outputDirectory}"]

let findNuGetPackage packagesDirectory =
    Directory.GetFiles(packagesDirectory, searchPattern = "*.nupkg") |> Seq.head

let testFileIsImportable packagesDirectory relativePath =
    printfn $"Testing {relativePath}"
    runProcess "dotnet" ["msbuild"; Path.Combine(packagesDirectory, relativePath); "-preprocess"]

let main =
    use tempDirectory = TempSubdirectory.Create("code-style-tests")
    let packagesDirectory = Path.Combine(tempDirectory.FullName, "nupkg")
    let unpackedDirectory = Path.Combine(tempDirectory.FullName, "unpacked")
    let importableFiles = ["build/Messerli.CodeStyle.props"]
    buildNuGetPackages packagesDirectory
    ZipFile.ExtractToDirectory((findNuGetPackage packagesDirectory), unpackedDirectory)
    importableFiles |> Seq.iter (testFileIsImportable unpackedDirectory)

main
