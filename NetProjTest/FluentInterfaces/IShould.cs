namespace NetProjTest.FluentInterfaces;

public interface IShould
{
    public IShouldNot Not();
    
    public IProject ContainPackage(string packageName);
    public IProject ContainPackage(string packageName, string version);
    public IProject ContainFile(string fileName);
    public IProject ContainFile(string fileName, string filePath);
}