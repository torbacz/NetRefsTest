using NetProjTest.Exceptions;
using NetProjTest.FluentInterfaces;
using NetProjTest.Models;
using NetProjTest.Models.Net60;
using Project = NetProjTest.Models.Project;

namespace NetProjTest;

internal class ProjectTester : IProject, IShould<IProject>, IShouldNot<IProject>
{
    private readonly Project projectFile;
    
    internal ProjectTester(Project projectFile)
    {
        this.projectFile = projectFile;
    }
    
    IProject IShould<IProject>.ContainPackage(string packageName)
    {
        var package = projectFile.Packages.FirstOrDefault(x=> x.PackageName == packageName);
        if (package == null)
            throw new PackageNotFoundException(projectFile.ProjectName, packageName);

        return this;
    }

    IProject IShould<IProject>.ContainPackage(string packageName, string version)
    {
        var package = projectFile.Packages.FirstOrDefault(x=> x.PackageName == packageName && x.Version == version);
        if (package == null)
            throw new PackageNotFoundException(projectFile.ProjectName, packageName, version);

        return this;
    }
    
    IProject IShouldNot<IProject>.ContainPackage(string packageName)
    {
        var package = projectFile.Packages.FirstOrDefault(x=> x.PackageName == packageName);
        if (package != null)
            throw new PackageFoundException(projectFile.ProjectName, packageName);

        return this;
    }

    IProject IShouldNot<IProject>.ContainPackage(string packageName, string version)
    {
        var package = projectFile.Packages.FirstOrDefault(x=> x.PackageName == packageName && x.Version == version);
        if (package != null)
            throw new PackageFoundException(projectFile.ProjectName, packageName, version);

        return this;
    }

    IProject IShouldNot<IProject>.ContainFile(string fileName)
    {
        var additionalFile = projectFile.Files.FirstOrDefault(x => x.FileName == fileName);
        if (additionalFile != null)
            throw new AdditionalFileFoundException(projectFile.ProjectName, fileName);

        return this;
    }

    IProject IShouldNot<IProject>.ContainFile(string fileName, string filePath)
    {
        var additionalFile = projectFile.Files.FirstOrDefault(x => x.FileName == fileName && x.FilePath == filePath);
        if (additionalFile != null)
            throw new AdditionalFileFoundException(projectFile.ProjectName, fileName, filePath);

        return this;
    }
    
    IProject IShould<IProject>.ContainFile(string fileName)
    {
        var additionalFile = projectFile.Files.FirstOrDefault(x => x.FileName == fileName);
        if (additionalFile == null)
            throw new AdditionalFileNotFoundException(projectFile.ProjectName, fileName);

        return this;
    }

    IProject IShould<IProject>.ContainFile(string fileName, string filePath)
    {
        var additionalFile = projectFile.Files.FirstOrDefault(x => x.FileName == fileName && x.FilePath == filePath);
        if (additionalFile == null)
            throw new AdditionalFileNotFoundException(projectFile.ProjectName, fileName, filePath);

        return this;
    }

    IProject IShouldNot<IProject>.TargetFramework(TargetFramework targetFramework)
    {
        if (targetFramework != projectFile.TargetFramework)
            throw new InvalidTargetFrameworkException(projectFile.ProjectName, targetFramework);

        return this;
    }

    IProject IShould<IProject>.TargetFramework(TargetFramework targetFramework)
    {
        if (targetFramework != projectFile.TargetFramework)
            throw new InvalidTargetFrameworkException(projectFile.ProjectName, targetFramework,
                projectFile.TargetFramework);

        return this;
    }

    public IShould<IProject> Should()
    {
        return this;
    }
    
    public IShouldNot<IProject> Not()
    {
        return this;
    }

}