namespace NetProjTest.Unit.Tests.BaseTests;

public abstract class BaseFromFileTest
{
    protected abstract string SampleProjectName { get; }
    protected string SampleProjectPath => $"TestSamples\\{SampleProjectNameWithExtenstion}";
    private string SampleProjectNameWithExtenstion => $"{SampleProjectName}.csproj";

}