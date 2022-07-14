using NetRefsTest.Exceptions;
using NetRefsTest.Models;

namespace NetRefsTest;

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
}