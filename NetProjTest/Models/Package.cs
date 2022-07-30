namespace NetProjTest.Models;

internal class Package
{
    public string PackageName { get; }
    public string Version { get; }

    public Package(string packageName, string version)
    {
        PackageName = packageName;
        Version = version;
    }
}