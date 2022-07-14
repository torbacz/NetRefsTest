using NetProjTest.Models;

namespace NetProjTest;

public interface IProject
{
    public static IProject FromFile(string filePath)
    {
        var frameworkVersion = ProjectHelper.FindTargetFrameworkBasedOnFile(filePath);
        return frameworkVersion switch
        {
            TargetFramework.Net60 => new ProjectNet(Project.FromFile(filePath)),
            _ => throw new ArgumentOutOfRangeException($"")
        };
    }

    public IProject ShouldContainPackage(string packageName);
    public IProject ShouldContainPackage(string packageName, string version);
    
    public IProject ShouldNotContainPackage(string packageName);
    public IProject ShouldNotContainPackage(string packageName, string version);
    public IProject ShouldContainAdditionalFile(string fileName);
    public IProject ShouldContainAdditionalFile(string fileName, string link);
}