using NetProjTest.Models;
using NetProjTest.Models.Net60;

namespace NetProjTest.FluentInterfaces;

public interface IShould<out T>
{
    public IShouldNot<T> Not();
    
    public T ContainPackage(string packageName);
    public T ContainPackage(string packageName, string version);
    public T ContainFile(string fileName);
    public T ContainFile(string fileName, string filePath);
    public T TargetFramework(TargetFramework targetFramework);
}