using NetProjTest.FluentInterfaces;
using NetProjTest.Models;
using NetProjTest.Models.Net60;

namespace NetProjTest;

public interface IProject
{
    public static IProject FromFile(string filePath)
    {
        var frameworkVersion = ProjectHelper.FindTargetFrameworkBasedOnFile(filePath);
        var projectModel = frameworkVersion switch
        {
            TargetFramework.Net60 => Project.FromNet60Project(Net60Project.FromFile(filePath)),
            _ => throw new ArgumentOutOfRangeException($"")
        };

        return new ProjectTester(projectModel);
    }

    public IShould Should();

}