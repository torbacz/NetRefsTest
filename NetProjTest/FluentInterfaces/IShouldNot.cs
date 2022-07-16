namespace NetProjTest.FluentInterfaces;

public interface IShouldNot
{
    public IProject NotContainPackage(string packageName);
    public IProject NotContainPackage(string packageName, string version);
}