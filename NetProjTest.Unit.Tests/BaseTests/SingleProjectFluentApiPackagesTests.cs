using NetProjTest.Exceptions;
using NetProjTest.Models.Net60;

namespace NetProjTest.Unit.Tests.BaseTests;

public abstract class SingleProjectFluentApiPackagesTests : BaseFromFileTest
{
    protected abstract string ExistingPackage { get; }
    protected abstract string ExistingPackageVersion { get; }
    protected abstract string NoExistingPackage { get; }
    protected abstract string NoExistingPackageVersion { get; }

    [Fact]
    public void ShouldContainPackage_Should_NotThrowErrorForValidPackage()
    {
        var project = IProject.FromFile(SampleProjectPath);

        FluentActions.Invoking(() => project
            .Should().ContainPackage(ExistingPackage)
            .Should().ContainPackage(ExistingPackage, ExistingPackageVersion)).Should().NotThrow();
    }

    [Fact]
    public void ShouldContainPackage_Should_ThrowErrorForInvalidPackage()
    {
        var project = IProject.FromFile(SampleProjectPath);

        FluentActions.Invoking(() => project.Should().ContainPackage(NoExistingPackage)).Should()
            .ThrowExactly<PackageNotFoundException>().And.Message.Should()
            .ContainAll(SampleProjectName, NoExistingPackage);
    }

    [Fact]
    public void ShouldContainPackage_Should_ThrowErrorForInvalidPackageVersion()
    {
        var project = IProject.FromFile(SampleProjectPath);

        FluentActions.Invoking(() => project.Should().ContainPackage(ExistingPackage, NoExistingPackageVersion)).Should()
            .ThrowExactly<PackageNotFoundException>().And.Message.Should()
            .ContainAll(SampleProjectName, ExistingPackage, NoExistingPackageVersion);
    }

    [Fact]
    public void ShouldNotContainPackage_Should_NotThrowErrorForInvalidPackage()
    {
        var project = IProject.FromFile(SampleProjectPath);

        FluentActions.Invoking(() => project
            .Should().Not().ContainPackage(NoExistingPackage)
            .Should().Not().ContainPackage(ExistingPackage, NoExistingPackageVersion)
        ).Should().NotThrow();
    }

    [Fact]
    public void ShouldNotContainPackage_Should_ThrowErrorForValidPackage()
    {
        var project = IProject.FromFile(SampleProjectPath);

        FluentActions.Invoking(() => project.Should().Not().ContainPackage(ExistingPackage)).Should()
            .ThrowExactly<PackageFoundException>().And.Message.Should()
            .ContainAll(SampleProjectName, ExistingPackage);
    }

    [Fact]
    public void ShouldNotContainPackage_Should_ThrowErrorForValidPackageAndVersion()
    {
        var project = IProject.FromFile(SampleProjectPath);

        FluentActions.Invoking(() => project.Should().Not().ContainPackage(ExistingPackage, ExistingPackageVersion)).Should()
            .ThrowExactly<PackageFoundException>().And.Message.Should()
            .ContainAll(SampleProjectName, ExistingPackage, ExistingPackageVersion);
    }
}