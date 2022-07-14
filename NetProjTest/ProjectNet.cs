using NetProjTest.Exceptions;
using NetProjTest.Models;

namespace NetProjTest;

internal class ProjectNet : IProject
{
    private readonly Project projectFile;
    
    internal ProjectNet(Project projectFile)
    {
        this.projectFile = projectFile;
    }

    private IEnumerable<PackageReference> FindPackagesInProjectStructure()
    {
        return projectFile.ItemGroups.SelectMany(x => x.PackageReferences);
    }

    private IEnumerable<AdditionalFile> FindAdditionalFilesInProjectStructure()
    {
        return projectFile.ItemGroups.SelectMany(x => x.AdditionalFiless);
    }

    public IProject ShouldContainPackage(string packageName)
    {
        var package = FindPackagesInProjectStructure().FirstOrDefault(x=> x.Include == packageName);
        if (package == null)
            throw new PackageNotFoundException(projectFile.ProjectName, packageName);

        return this;
    }

    public IProject ShouldContainPackage(string packageName, string version)
    {
        var package = FindPackagesInProjectStructure().FirstOrDefault(x=> x.Include == packageName && x.Version == version);
        if (package == null)
            throw new PackageNotFoundException(projectFile.ProjectName, packageName, version);

        return this;
    }

    public IProject ShouldNotContainPackage(string packageName)
    {
        var package = FindPackagesInProjectStructure().FirstOrDefault(x=> x.Include == packageName);
        if (package != null)
            throw new PackageFoundException(projectFile.ProjectName, packageName);

        return this;
    }

    public IProject ShouldNotContainPackage(string packageName, string version)
    {
        var package = FindPackagesInProjectStructure().FirstOrDefault(x=> x.Include == packageName && x.Version == version);
        if (package != null)
            throw new PackageFoundException(projectFile.ProjectName, packageName, version);

        return this;
    }

    public IProject ShouldContainAdditionalFile(string fileName)
    {
        var additionalFile = FindAdditionalFilesInProjectStructure().FirstOrDefault(x => x.Include == fileName);
        if (additionalFile == null)
            throw new AdditionalFileNotFoundException(projectFile.ProjectName, fileName);

        return this;
    }
    
    public IProject ShouldContainAdditionalFile(string fileName, string link)
    {
        var additionalFile = FindAdditionalFilesInProjectStructure().FirstOrDefault(x => x.Include == fileName && x.Link == link);
        if (additionalFile == null)
            throw new AdditionalFileNotFoundException(projectFile.ProjectName, fileName, link);

        return this;
    }
}