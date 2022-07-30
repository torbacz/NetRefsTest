using NetProjTest.FluentInterfaces;
using NetProjTest.Models;
using NetProjTest.Models.Net60;
using NetProjTest.Models.NetFramework;

namespace NetProjTest;

public interface IProject
{
    public static IProject FromFile(string filePath)
    {
        var frameworkVersion = ProjectHelper.FindTargetFrameworkBasedOnFile(filePath);
        var projectModel = frameworkVersion switch
        {
            TargetFramework.Net60 => Project.FromNet60Project(Net60Project.FromFile(filePath)),
            TargetFramework.NetFramework => Project.FromNetFrameworkProject(NetFrameworkProject.FromFile(filePath)),
            _ => throw new ArgumentOutOfRangeException($"")
        };

        return new ProjectTester(projectModel);
    }

    public IShould<IProject> Should();
}