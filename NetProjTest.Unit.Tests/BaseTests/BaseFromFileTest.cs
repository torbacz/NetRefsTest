namespace NetProjTest.Unit.Tests.BaseTests;

public abstract class BaseFromFileTest
{
    protected string SampleProjectName => Path.GetFileNameWithoutExtension(SampleProjectPath);
    protected abstract string SampleProjectPath { get; }

}