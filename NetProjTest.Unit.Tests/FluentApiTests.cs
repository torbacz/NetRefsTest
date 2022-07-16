using NetProjTest.Exceptions;

namespace NetProjTest.Unit.Tests;

public class FluentApiTests : IDisposable
{
    private const string sampleProjectName = "sampleProjectNet60";
    private const string sampleProjectNameWithExtenstion = $"{sampleProjectName}.csproj";
    private const string sampleProjectPath = $"{sampleProjectNameWithExtenstion}";

    public FluentApiTests()
    {
        File.WriteAllText(sampleProjectPath, ProjectSamples.testProjectNet60_1);
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
            .Should().Not().NotContainPackage("StyleCop.Analyzers1")
            .Should().Not().NotContainPackage("StyleCop.Analyzers", "1.2.0-beta.430")
        ).Should().NotThrow();
    }

    [Fact]
    public void ShouldNotContainPackage_Should_ThrowErrorForValidPackage()
    {
        var project = IProject.FromFile(sampleProjectPath);

        FluentActions.Invoking(() => project.Should().Not().NotContainPackage("StyleCop.Analyzers")).Should()
            .ThrowExactly<PackageFoundException>().And.Message.Should()
            .ContainAll(sampleProjectName, "StyleCop.Analyzers");
    }

    [Fact]
    public void ShouldNotContainPackage_Should_ThrowErrorForValidPackageAndVersion()
    {
        var project = IProject.FromFile(sampleProjectPath);

        FluentActions.Invoking(() => project.Should().Not().NotContainPackage("StyleCop.Analyzers", "1.2.0-beta.435")).Should()
            .ThrowExactly<PackageFoundException>().And.Message.Should()
            .ContainAll(sampleProjectName, "StyleCop.Analyzers", "1.2.0-beta.435");
    }

    [Fact]
    public void ShouldContainAdditionalFile_Should_NotThrowErrorForValidFile()
    {
        var project = IProject.FromFile(sampleProjectPath);

        FluentActions.Invoking(() => project.Should().ContainFile("stylecop.json", "..\\stylecop.json")).Should()
            .NotThrow();
    }

    public void Dispose()
    {
        if (File.Exists(sampleProjectPath))
            File.Delete(sampleProjectPath);
    }
}