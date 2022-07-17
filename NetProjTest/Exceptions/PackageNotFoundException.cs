namespace NetProjTest.Exceptions;

public sealed class PackageNotFoundException : Exception
{
    internal  PackageNotFoundException(string projectName, string packageName) : base(
        $"Package {packageName} not found in project {projectName}")
    {
    }
    
    internal  PackageNotFoundException(string projectName, string packageName, string version) : base(
        $"Package {packageName} version {version} not found in project {projectName}")
    {
    }
}