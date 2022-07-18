namespace NetProjTest.Exceptions;

public sealed class PackageFoundException : Exception
{
    internal  PackageFoundException(string projectName, string packageName) : base(
        $"Package {packageName} found in project {projectName}")
    {
    }
    
    internal  PackageFoundException(string projectName, string packageName, string version) : base(
        $"Package {packageName} version {version} found in project {projectName}")
    {
    }
}