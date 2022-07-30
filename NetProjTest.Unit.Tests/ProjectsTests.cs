namespace NetProjTest.Unit.Tests;

public class ProjectsTests
{
    private static string SearchPath => $"{Environment.CurrentDirectory}/TestSamples";
        
    [Fact]
    public void SearchFiles_Should_ReturnAllFiles()
    {
        var allFiles = IProjects.SearchFiles(SearchPath, "*.csproj", SearchOption.TopDirectoryOnly).ToArray();
        
        allFiles.Length.Should().Be(2);
        allFiles.Should().Contain(x => x.Contains("Net60WithPackageAndFile"));
        allFiles.Should().Contain(x => x.Contains("Net60Simple"));
    }
    
    [Fact]
    public void SearchFiles_Should_ReturnAsIEnumerable()
    {
        var allFiles = IProjects.SearchFiles(SearchPath, "*.csproj", SearchOption.TopDirectoryOnly);

        allFiles.Should().BeAssignableTo<IEnumerable<string>>();
    }
    
    [Fact]
    public void FromFiles_Should_ReturnValidData()
    {
        var allFiles = IProjects.SearchFiles(SearchPath, "*.csproj", SearchOption.AllDirectories)
            .ToArray();

        if (IProjects.FromFiles(allFiles) is not ProjectsTester projects)
            throw new InvalidCastException($"Returned type must be of type {typeof(ProjectsTester)}");

        projects.Projects.Count().Should().Be(3);
    }
}