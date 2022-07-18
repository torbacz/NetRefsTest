namespace NetProjTest.Unit.Tests;

public class IProjectsTests
{
    private const string SampleProjectNameFirst = "sampleProjectNet60First";
    private const string SampleProjectNameWithExtenstionFirst = $"{SampleProjectNameFirst}.csproj";
    private const string SampleProjectPathFirst = $"{SampleProjectNameWithExtenstionFirst}";
    
    private const string SampleProjectNameSecond = "sampleProjectNet60Second";
    private const string SampleProjectNameWithExtenstionSecond = $"{SampleProjectNameSecond}.csproj";
    private const string SampleProjectPathSecond = $"{SampleProjectNameWithExtenstionSecond}";
    
    public IProjectsTests()
    {
        File.WriteAllText(SampleProjectPathFirst, ProjectSamples.testProjectNet60_Simple);
        File.WriteAllText(SampleProjectPathSecond, ProjectSamples.testProjectNet60_Simple);
    }
    
    [Fact]
    public void SearchFiles_Should_ReturnAllFiles()
    {
        var allFiles = IProjects.SearchFiles(Environment.CurrentDirectory, "*.csproj", SearchOption.TopDirectoryOnly).ToArray();
        
        allFiles.Length.Should().Be(2);
        allFiles.Should().Contain(x => x.Contains(SampleProjectNameWithExtenstionFirst));
        allFiles.Should().Contain(x => x.Contains(SampleProjectNameWithExtenstionSecond));
    }
    
    [Fact]
    public void SearchFiles_Should_ReturnAsIEnumerable()
    {
        var allFiles = IProjects.SearchFiles(Environment.CurrentDirectory, "*.csproj", SearchOption.TopDirectoryOnly);

        allFiles.Should().BeAssignableTo<IEnumerable<string>>();
    }
    
    [Fact]
    public void FromFiles_Should_ReturnValidData()
    {
        var allFiles = IProjects.SearchFiles(Environment.CurrentDirectory, "*.csproj", SearchOption.TopDirectoryOnly)
            .ToArray();

        if (IProjects.FromFiles(allFiles) is not ProjectsTester projects)
            throw new InvalidCastException($"Returned type must be of type {typeof(ProjectsTester)}");

        projects.Projects.Count().Should().Be(2);
    }
}