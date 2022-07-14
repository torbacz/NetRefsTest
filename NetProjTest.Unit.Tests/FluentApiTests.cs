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
            .ShouldContainPackage("StyleCop.Analyzers")
            .ShouldContainPackage("StyleCop.Analyzers", "1.2.0-beta.435")).Should().NotThrow();
    }

    [Fact]
    public void ShouldContainPackage_Should_ThrowErrorForInvalidPackage()
    {
        var project = IProject.FromFile(sampleProjectPath);

        FluentActions.Invoking(() => project.ShouldContainPackage("StyleCop.Analyzers1")).Should()
            .ThrowExactly<PackageNotFoundException>().And.Message.Should()
            .ContainAll(sampleProjectName, "StyleCop.Analyzers1");
    }

    [Fact]
    public void ShouldContainPackage_Should_ThrowErrorForInvalidPackageVersion()
    {
        var project = IProject.FromFile(sampleProjectPath);

        FluentActions.Invoking(() => project.ShouldContainPackage("StyleCop.Analyzers", "1.2.0-beta.430")).Should()
            .ThrowExactly<PackageNotFoundException>().And.Message.Should()
            .ContainAll(sampleProjectName, "StyleCop.Analyzers", "1.2.0-beta.430");
    }

    [Fact]
    public void ShouldNotContainPackage_Should_NotThrowErrorForInvalidPackage()
    {
        var project = IProject.FromFile(sampleProjectPath);

        FluentActions.Invoking(() => project
            .ShouldNotContainPackage("StyleCop.Analyzers1")
            .ShouldNotContainPackage("StyleCop.Analyzers", "1.2.0-beta.430")
        ).Should().NotThrow();
    }

    [Fact]
    public void ShouldNotContainPackage_Should_ThrowErrorForValidPackage()
    {
        var project = IProject.FromFile(sampleProjectPath);

        FluentActions.Invoking(() => project.ShouldNotContainPackage("StyleCop.Analyzers")).Should()
            .ThrowExactly<PackageFoundException>().And.Message.Should()
            .ContainAll(sampleProjectName, "StyleCop.Analyzers");
    }

    [Fact]
    public void ShouldNotContainPackage_Should_ThrowErrorForValidPackageAndVersion()
    {
        var project = IProject.FromFile(sampleProjectPath);

        FluentActions.Invoking(() => project.ShouldNotContainPackage("StyleCop.Analyzers", "1.2.0-beta.435")).Should()
            .ThrowExactly<PackageFoundException>().And.Message.Should()
            .ContainAll(sampleProjectName, "StyleCop.Analyzers", "1.2.0-beta.435");
    }

    [Fact]
    public void ShouldContainAdditionalFile_Should_NotThrowErrorForValidFile()
    {
        var project = IProject.FromFile(sampleProjectPath);

        FluentActions.Invoking(() => project.ShouldContainAdditionalFile("..\\stylecop.json")).Should()
            .NotThrow();
    }

    public void Dispose()
    {
        if (File.Exists(sampleProjectPath))
            File.Delete(sampleProjectPath);
    }
}