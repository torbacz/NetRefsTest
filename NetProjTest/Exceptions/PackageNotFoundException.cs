namespace NetProjTest.Exceptions;

public sealed class PackageNotFoundException : Exception
{
    public PackageNotFoundException(string projectName, string packageName) : base(
        $"Package {packageName} not found in project {projectName}")
    {
    }
    
    public PackageNotFoundException(string projectName, string packageName, string version) : base(
        $"Package {packageName} version {version} not found in project {projectName}")
    {
    }
}