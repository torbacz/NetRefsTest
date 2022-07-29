using NetProjTest.Exceptions;

namespace NetProjTest.Unit.Tests.BaseTests;

public abstract class SingleProjectFluentApiFromFilesTests : BaseFromFileTest
{
    protected abstract string ExistingFileName { get; }
    protected abstract string NoExistingFileName { get; }
    protected abstract string ExistingFilePath { get; }
    protected abstract string NoExistingFilePath { get; }
        
    [Fact]
    public void ShouldContainAdditionalFile_Should_NotThrowErrorForValidFileWithLink()
    {
        var project = IProject.FromFile(SampleProjectPath);

        FluentActions.Invoking(() => project.Should().ContainFile(ExistingFileName, ExistingFilePath)).Should()
            .NotThrow();
    }
    
    [Fact]
    public void ShouldContainAdditionalFile_Should_ThrowErrorForInvalidFileWithLink()
    {
        var project = IProject.FromFile(SampleProjectPath);

        FluentActions.Invoking(() => project.Should().ContainFile(NoExistingFileName, ExistingFilePath)).Should()
            .ThrowExactly<AdditionalFileNotFoundException>().And.Message.Should()
            .ContainAll(SampleProjectName, NoExistingFileName, ExistingFilePath);
    }
    
    [Fact]
    public void ShouldContainAdditionalFile_Should_NotThrowErrorForValidFile()
    {
        var project = IProject.FromFile(SampleProjectPath);

        FluentActions.Invoking(() => project.Should().ContainFile(ExistingFileName)).Should()
            .NotThrow();
    }
    
    [Fact]
    public void ShouldContainAdditionalFile_Should_ThrowErrorForInvalidFile()
    {
        var project = IProject.FromFile(SampleProjectPath);

        FluentActions.Invoking(() => project.Should().ContainFile(NoExistingFileName)).Should()
            .ThrowExactly<AdditionalFileNotFoundException>().And.Message.Should()
            .ContainAll(SampleProjectName, NoExistingFileName);
    }
    
    [Fact]
    public void ShouldNotContainAdditionalFile_Should_NotThrowErrorForInvalidFile()
    {
        var project = IProject.FromFile(SampleProjectPath);

        FluentActions.Invoking(() => project.Should().Not().ContainFile(NoExistingFileName)).Should()
            .NotThrow();
    }

    [Fact]
    public void ShouldNotContainAdditionalFile_Should_ThrowErrorForValidFile()
    {
        var project = IProject.FromFile(SampleProjectPath);

        FluentActions.Invoking(() => project.Should().Not().ContainFile(ExistingFileName)).Should()
            .ThrowExactly<AdditionalFileFoundException>().And.Message.Should()
            .ContainAll(SampleProjectName, ExistingFileName);
    }
    
    [Fact]
    public void ShouldNotContainAdditionalFile_Should_NotThrowErrorForInvalidFileWithLink()
    {
        var project = IProject.FromFile(SampleProjectPath);

        FluentActions.Invoking(() => project.Should().Not().ContainFile(ExistingFileName, NoExistingFilePath)).Should()
            .NotThrow();
    }

    [Fact]
    public void ShouldNotContainAdditionalFile_Should_ThrowErrorForValidFileWithLink()
    {
        var project = IProject.FromFile(SampleProjectPath);

        FluentActions.Invoking(() => project.Should().Not().ContainFile(ExistingFileName, ExistingFilePath)).Should()
            .ThrowExactly<AdditionalFileFoundException>().And.Message.Should()
            .ContainAll(SampleProjectName, ExistingFileName, ExistingFilePath);
    }
}