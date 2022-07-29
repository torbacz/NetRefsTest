using NetProjTest.Exceptions;
using NetProjTest.Models.Net60;

namespace NetProjTest.Unit.Tests.BaseTests;

public abstract class SingleProjectFluentApiTargetFrameworkTests : BaseFromFileTest
{
    public abstract TargetFramework TargetFramework { get; }
    
    [Fact]
    public void ShouldTargetFramework_Should_NotThrowForValidFramework()
    {
        var project = IProject.FromFile(SampleProjectPath);

        FluentActions.Invoking(() => project.Should().TargetFramework(TargetFramework)).Should()
            .NotThrow();
    }
    
    [Fact]
    public void ShouldTargetFramework_Should_ThrowForInvalidFramework()
    {
        var invalidTargetFramework = (TargetFramework)(-1);
        
        var project = IProject.FromFile(SampleProjectPath);
        FluentActions.Invoking(() => project.Should().TargetFramework(invalidTargetFramework)).Should()
            .ThrowExactly<InvalidTargetFrameworkException>().And.Message.Should()
            .ContainAll(SampleProjectName, invalidTargetFramework.ToString(), TargetFramework.ToString());
    }
    
    [Fact]
    public void ShouldNMotTargetFramework_Should_ThrowForInvalidFramework()
    {
        var project = IProject.FromFile(SampleProjectPath);
        FluentActions.Invoking(() => project.Should().Not().TargetFramework(TargetFramework)).Should()
            .NotThrow();
    }
    
    [Fact]
    public void ShouldNotTargetFramework_Should_NotThrowForInvalidFramework()
    {
        var invalidTargetFramework = (TargetFramework)(-1);
        var project = IProject.FromFile(SampleProjectPath);

        FluentActions.Invoking(() => project.Should().Not().TargetFramework(invalidTargetFramework)).Should()
            .ThrowExactly<InvalidTargetFrameworkException>().And.Message.Should()
            .ContainAll(SampleProjectName, invalidTargetFramework.ToString());
    }
}