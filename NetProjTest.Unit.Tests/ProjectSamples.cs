namespace NetProjTest.Unit.Tests;

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