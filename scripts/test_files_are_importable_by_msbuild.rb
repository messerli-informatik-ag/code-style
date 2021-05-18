#!/usr/bin/env ruby

require 'tmpdir'
require 'fileutils'

def run_command(program, arguments, **kwargs)
    system [program, program], *arguments, **kwargs, exception: true
end

def lift_permissions_recursively(directory)
    glob = File.join directory, '**', '*'
    files = Dir.glob glob
    File.chmod 0777, *files
end

def build_nuget_package(output_directory)
    FileUtils.mkdir_p output_directory
    run_command 'dotnet', ['pack', 'CodeStyle/CodeStyle.csproj', "/p:PackageOutputPath=#{output_directory}"]
end

def unpack_nuget_packages(source_directory, output_directory)
    packages_glob = File.join source_directory, '*.nupkg'
    packages = Dir.glob packages_glob

    FileUtils.mkdir_p output_directory

    packages.each do |package|
        run_command 'unzip', package, chdir: output_directory
    end

    lift_permissions_recursively output_directory
end

def test_files_are_importable_by_msbuild(directory, files_to_test)
    files_to_test.each do |file|
        file_path = File.join directory, file
        puts "Testing #{file_path}"
        run_command 'dotnet', ['msbuild', file_path, '-preprocess']
    end
end

Dir.mktmpdir do |temp_directory|
    package_directory = File.join temp_directory, 'package'
    unpacked_directory = File.join temp_directory, 'unpacked'

    build_nuget_package package_directory
    unpack_nuget_packages package_directory, unpacked_directory

    test_files_are_importable_by_msbuild unpacked_directory, [
        'build/Messerli.CodeStyle.props',
    ]
end
