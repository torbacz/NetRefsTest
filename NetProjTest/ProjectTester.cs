using NetProjTest.Exceptions;
using NetProjTest.FluentInterfaces;
using Project = NetProjTest.Models.Project;

namespace NetProjTest;

internal class ProjectTester : IProject, IShould, IShouldNot
{
    private readonly Project projectFile;
    
    internal ProjectTester(Project projectFile)
    {
        this.projectFile = projectFile;
    }
    
    public IProject ContainPackage(string packageName)
    {
        var package = projectFile.Packages.FirstOrDefault(x=> x.PackageName == packageName);
        if (package == null)
            throw new PackageNotFoundException(projectFile.ProjectName, packageName);

        return this;
    }

    public IProject ContainPackage(string packageName, string version)
    {
        var package = projectFile.Packages.FirstOrDefault(x=> x.PackageName == packageName && x.Version == version);
        if (package == null)
            throw new PackageNotFoundException(projectFile.ProjectName, packageName, version);

        return this;
    }

    public IProject NotContainPackage(string packageName)
    {
        var package = projectFile.Packages.FirstOrDefault(x=> x.PackageName == packageName);
        if (package != null)
            throw new PackageFoundException(projectFile.ProjectName, packageName);

        return this;
    }

    public IProject NotContainPackage(string packageName, string version)
    {
        var package = projectFile.Packages.FirstOrDefault(x=> x.PackageName == packageName && x.Version == version);
        if (package != null)
            throw new PackageFoundException(projectFile.ProjectName, packageName, version);

        return this;
    }

    public IProject ContainFile(string fileName)
    {
        var additionalFile = projectFile.Files.FirstOrDefault(x => x.FileName == fileName);
        if (additionalFile == null)
            throw new AdditionalFileNotFoundException(projectFile.ProjectName, fileName);

        return this;
    }
    
    public IProject ContainFile(string fileName, string filePath)
    {
        var additionalFile = projectFile.Files.FirstOrDefault(x => x.FileName == fileName && x.FilePath == filePath);
        if (additionalFile == null)
            throw new AdditionalFileNotFoundException(projectFile.ProjectName, fileName, filePath);

        return this;
    }

    public IShould Should()
    {
        return this;
    }
    
    public IShouldNot Not()
    {
        return this;
    }

}