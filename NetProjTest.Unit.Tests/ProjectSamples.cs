﻿namespace NetProjTest.Unit.Tests;

public class ProjectSamples
{
    internal static string testProjectNet60_Simple = @"<Project Sdk=""Microsoft.NET.Sdk"">
    <PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
    <EnforceCodeStyleInBuild>True</EnforceCodeStyleInBuild>
    <GenerateDocumentationFile>True</GenerateDocumentationFile>
    </PropertyGroup>

    </Project>";
    
    internal static string testProjectNet60_WithPackageAndFile = @"<Project Sdk=""Microsoft.NET.Sdk"">
    <PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
    <EnforceCodeStyleInBuild>True</EnforceCodeStyleInBuild>
    <GenerateDocumentationFile>True</GenerateDocumentationFile>
    </PropertyGroup>

    <PropertyGroup Condition=""'$(Configuration)|$(Platform)'=='Debug|AnyCPU'"">
        <CheckForOverflowUnderflow>True</CheckForOverflowUnderflow>
    </PropertyGroup>

    <PropertyGroup Condition=""'$(Configuration)|$(Platform)'=='Release|AnyCPU'"">
        <CheckForOverflowUnderflow>True</CheckForOverflowUnderflow>
    </PropertyGroup>
    
    <ItemGroup>
    <PackageReference Include=""StyleCop.Analyzers"" Version=""1.2.0-beta.435"">
    <PrivateAssets>all</PrivateAssets>
    <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
    </ItemGroup>
    
    <ItemGroup>
    <AdditionalFiles Include=""..\stylecop.json"">
        <Link>stylecop.json</Link>
    </AdditionalFiles>
    </ItemGroup>

    </Project>";
    
    internal static string testProjectInvalidFramework = @"<Project Sdk=""Microsoft.NET.Sdk"">
    <PropertyGroup>
    <TargetFramework>InvalidFramework</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
    <EnforceCodeStyleInBuild>True</EnforceCodeStyleInBuild>
    <GenerateDocumentationFile>True</GenerateDocumentationFile>
    </PropertyGroup>

    </Project>";
}