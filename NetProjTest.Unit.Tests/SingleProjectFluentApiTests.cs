using NetProjTest.Exceptions;
using NetProjTest.Models.Net60;

namespace NetProjTest.Unit.Tests;

public class SingleProjectFluentApiTests : IDisposable
{
    private const string sampleProjectName = "sampleProjectNet60";
    private const string sampleProjectNameWithExtenstion = $"{sampleProjectName}.csproj";
    private const string sampleProjectPath = $"{sampleProjectNameWithExtenstion}";

    public SingleProjectFluentApiTests()
    {
        File.WriteAllText(sampleProjectPath, ProjectSamples.testProjectNet60_WithPackageAndFile);
    }

    [Fact]
    public void ShouldContainPackage_Should_NotThrowErrorForValidPackage()
    {
        var project = IProject.FromFile(sampleProjectPath);

        FluentActions.Invoking(() => project
            .Should().ContainPackage("StyleCop.Analyzers")
            .Should().ContainPackage("StyleCop.Analyzers", "1.2.0-beta.435")).Should().NotThrow();
    }

    [Fact]
    public void ShouldContainPackage_Should_ThrowErrorForInvalidPackage()
    {
        var project = IProject.FromFile(sampleProjectPath);

        FluentActions.Invoking(() => project.Should().ContainPackage("StyleCop.Analyzers1")).Should()
            .ThrowExactly<PackageNotFoundException>().And.Message.Should()
            .ContainAll(sampleProjectName, "StyleCop.Analyzers1");
    }

    [Fact]
    public void ShouldContainPackage_Should_ThrowErrorForInvalidPackageVersion()
    {
        var project = IProject.FromFile(sampleProjectPath);

        FluentActions.Invoking(() => project.Should().ContainPackage("StyleCop.Analyzers", "1.2.0-beta.430")).Should()
            .ThrowExactly<PackageNotFoundException>().And.Message.Should()
            .ContainAll(sampleProjectName, "StyleCop.Analyzers", "1.2.0-beta.430");
    }

    [Fact]
    public void ShouldNotContainPackage_Should_NotThrowErrorForInvalidPackage()
    {
        var project = IProject.FromFile(sampleProjectPath);

        FluentActions.Invoking(() => project
            .Should().Not().ContainPackage("StyleCop.Analyzers1")
            .Should().Not().ContainPackage("StyleCop.Analyzers", "1.2.0-beta.430")
        ).Should().NotThrow();
    }

    [Fact]
    public void ShouldNotContainPackage_Should_ThrowErrorForValidPackage()
    {
        var project = IProject.FromFile(sampleProjectPath);

        FluentActions.Invoking(() => project.Should().Not().ContainPackage("StyleCop.Analyzers")).Should()
            .ThrowExactly<PackageFoundException>().And.Message.Should()
            .ContainAll(sampleProjectName, "StyleCop.Analyzers");
    }

    [Fact]
    public void ShouldNotContainPackage_Should_ThrowErrorForValidPackageAndVersion()
    {
        var project = IProject.FromFile(sampleProjectPath);

        FluentActions.Invoking(() => project.Should().Not().ContainPackage("StyleCop.Analyzers", "1.2.0-beta.435")).Should()
            .ThrowExactly<PackageFoundException>().And.Message.Should()
            .ContainAll(sampleProjectName, "StyleCop.Analyzers", "1.2.0-beta.435");
    }

    [Fact]
    public void ShouldContainAdditionalFile_Should_NotThrowErrorForValidFileWithLink()
    {
        var project = IProject.FromFile(sampleProjectPath);

        FluentActions.Invoking(() => project.Should().ContainFile("stylecop.json", "..\\stylecop.json")).Should()
            .NotThrow();
    }
    
    [Fact]
    public void ShouldContainAdditionalFile_Should_ThrowErrorForInvalidFileWithLink()
    {
        var project = IProject.FromFile(sampleProjectPath);

        FluentActions.Invoking(() => project.Should().ContainFile("stylecop1.json", "..\\stylecop.json")).Should()
            .ThrowExactly<AdditionalFileNotFoundException>().And.Message.Should()
            .ContainAll(sampleProjectName, "stylecop1.json", "..\\stylecop.json");
    }
    
    [Fact]
    public void ShouldContainAdditionalFile_Should_NotThrowErrorForValidFile()
    {
        var project = IProject.FromFile(sampleProjectPath);

        FluentActions.Invoking(() => project.Should().ContainFile("stylecop.json")).Should()
            .NotThrow();
    }
    
    [Fact]
    public void ShouldContainAdditionalFile_Should_ThrowErrorForInvalidFile()
    {
        var project = IProject.FromFile(sampleProjectPath);

        FluentActions.Invoking(() => project.Should().ContainFile("stylecop1.json")).Should()
            .ThrowExactly<AdditionalFileNotFoundException>().And.Message.Should()
            .ContainAll(sampleProjectName, "stylecop1.json");
    }

    [Fact]
    public void ShouldTargetFramework_Should_NotThrowForValidFramework()
    {
        var project = IProject.FromFile(sampleProjectPath);

        FluentActions.Invoking(() => project.Should().TargetFramework(TargetFramework.Net60)).Should()
            .NotThrow();
    }
    
    [Fact]
    public void ShouldTargetFramework_Should_ThrowForInvalidFramework()
    {
        var invalidTargetFramework = (TargetFramework)(-1);
        
        var project = IProject.FromFile(sampleProjectPath);
        FluentActions.Invoking(() => project.Should().TargetFramework(invalidTargetFramework)).Should()
            .ThrowExactly<InvalidTargetFrameworkException>().And.Message.Should()
            .ContainAll(sampleProjectName, invalidTargetFramework.ToString(), TargetFramework.Net60.ToString());
    }

    [Fact]
    public void ShouldNotContainAdditionalFile_Should_NotThrowErrorForInvalidFile()
    {
        var project = IProject.FromFile(sampleProjectPath);

        FluentActions.Invoking(() => project.Should().Not().ContainFile("stylecop1.json")).Should()
            .NotThrow();
    }

    [Fact]
    public void ShouldNotContainAdditionalFile_Should_ThrowErrorForValidFile()
    {
        var project = IProject.FromFile(sampleProjectPath);

        FluentActions.Invoking(() => project.Should().Not().ContainFile("stylecop.json")).Should()
            .ThrowExactly<AdditionalFileFoundException>().And.Message.Should()
            .ContainAll(sampleProjectName, "stylecop.json");
    }
    
    [Fact]
    public void ShouldNotContainAdditionalFile_Should_NotThrowErrorForInvalidFileWithLink()
    {
        var project = IProject.FromFile(sampleProjectPath);

        FluentActions.Invoking(() => project.Should().Not().ContainFile("stylecop.json", "testPath")).Should()
            .NotThrow();
    }

    [Fact]
    public void ShouldNotContainAdditionalFile_Should_ThrowErrorForValidFileWithLink()
    {
        var project = IProject.FromFile(sampleProjectPath);

        FluentActions.Invoking(() => project.Should().Not().ContainFile("stylecop.json", "..\\stylecop.json")).Should()
            .ThrowExactly<AdditionalFileFoundException>().And.Message.Should()
            .ContainAll(sampleProjectName, "stylecop.json", "..\\stylecop.json");
    }
    
    [Fact]
    public void ShouldNotTargetFramework_Should_NotThrowForInvalidFramework()
    {
        var invalidTargetFramework = (TargetFramework)(-1);
        var project = IProject.FromFile(sampleProjectPath);

        FluentActions.Invoking(() => project.Should().Not().TargetFramework(invalidTargetFramework)).Should()
            .ThrowExactly<InvalidTargetFrameworkException>().And.Message.Should()
            .ContainAll(sampleProjectName, invalidTargetFramework.ToString());
        
    }
    
    [Fact]
    public void ShouldNMotTargetFramework_Should_ThrowForInvalidFramework()
    {
        var project = IProject.FromFile(sampleProjectPath);
        FluentActions.Invoking(() => project.Should().Not().TargetFramework(TargetFramework.Net60)).Should()
            .NotThrow();
    }

    public void Dispose()
    {
        if (File.Exists(sampleProjectPath))
            File.Delete(sampleProjectPath);
    }
}