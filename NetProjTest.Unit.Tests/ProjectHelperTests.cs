namespace NetProjTest.Unit.Tests;

public class ProjectHelperTests
{
    [Fact]
    public void FindTargetFrameworkBasedOnFile_Should_ThrowForEmptyPath()
    {
        FluentActions.Invoking(() => ProjectHelper.FindTargetFrameworkBasedOnFile(string.Empty)).Should().Throw<ArgumentException>();
    }
    
    [Fact]
    public void FindTargetFrameworkBasedOnFile_Should_ThrowForInvalidPath()
    {
        FluentActions.Invoking(() => ProjectHelper.FindTargetFrameworkBasedOnFile("InvalidPath")).Should().Throw<FileNotFoundException>();
    }
    
}