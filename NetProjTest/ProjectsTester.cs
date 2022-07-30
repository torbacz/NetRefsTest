using NetProjTest.FluentInterfaces;
using NetProjTest.Models;
using NetProjTest.Models.Net60;

namespace NetProjTest;

internal class ProjectsTester : IProjects, IShould<IProjects>, IShouldNot<IProjects>
{
    internal readonly IReadOnlyList<IProject> Projects;
    
    internal ProjectsTester(IReadOnlyList<IProject> projects)
    {
        Projects = projects;
    }
    
    public IShould<IProjects> Should()
    {
        return this;
    }

    public IShouldNot<IProjects> Not()
    {
        return this;
    }

    IProjects IShould<IProjects>.ContainPackage(string packageName)
    {
        foreach (var project in Projects)
            project.Should().ContainPackage(packageName);

        return this;
    }
    
    IProjects IShould<IProjects>.ContainPackage(string packageName, string version)
    {
        foreach (var project in Projects)
            project.Should().ContainPackage(packageName, version);

        return this;
    }

    IProjects IShouldNot<IProjects>.ContainFile(string fileName)
    {
        foreach (var project in Projects)
            project.Should().Not().ContainFile(fileName);

        return this;
    }

    IProjects IShouldNot<IProjects>.ContainFile(string fileName, string filePath)
    {
        foreach (var project in Projects)
            project.Should().Not().ContainFile(fileName, filePath);

        return this;
    }

    IProjects IShouldNot<IProjects>.TargetFramework(TargetFramework targetFramework)
    {
        foreach (var project in Projects)
            project.Should().Not().TargetFramework(targetFramework);

        return this;
    }
    
    IProjects IShould<IProjects>.ContainFile(string fileName)
    {
        foreach (var project in Projects)
            project.Should().ContainFile(fileName);
        
        return this;
    }

    IProjects IShould<IProjects>.ContainFile(string fileName, string filePath)
    {
        foreach (var project in Projects)
            project.Should().ContainFile(fileName, filePath);
        
        return this;
    }

    IProjects IShould<IProjects>.TargetFramework(TargetFramework targetFramework)
    {
        foreach (var project in Projects)
            project.Should().TargetFramework(targetFramework);
        
        return this;
    }

    IProjects IShouldNot<IProjects>.ContainPackage(string packageName)
    {
        foreach (var project in Projects)
            project.Should().Not().ContainPackage(packageName);
        
        return this;
    }
    
    IProjects IShouldNot<IProjects>.ContainPackage(string packageName, string version)
    {
        foreach (var project in Projects)
            project.Should().Not().ContainPackage(packageName, version);
        
        return this;
    }



}