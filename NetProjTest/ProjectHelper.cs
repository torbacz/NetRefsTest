using NetProjTest.Models.Net60;
using File = System.IO.File;

namespace NetProjTest;

public static class ProjectHelper
{
    public static TargetFramework FindTargetFrameworkBasedOnFile(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(filePath));

        if (!File.Exists(filePath))
            throw new FileNotFoundException($"File {filePath} not exists.");

        var fileContent = File.ReadAllText(filePath);
        var fileExtenstion = Path.GetExtension(filePath);

        if (IsNet60Project(fileContent, fileExtenstion))
            return TargetFramework.Net60;

        if (IsNetFrameworkProject(fileContent, fileExtenstion))
            return TargetFramework.NetFramework;

        throw new NotSupportedException($"Requested project is not supported");
    }

    private static bool IsNetFrameworkProject(string fileContent, string fileExtenstion)
    {
        if (fileExtenstion != ".csproj")
            return false;
        
        if (fileContent.Contains("<TargetFrameworkVersion>v4.7.2</TargetFrameworkVersion>"))
            return true;
        
        if (fileContent.Contains("<TargetFrameworkVersion>v4.8</TargetFrameworkVersion>"))
            return true;

        return false;
    }

    private static bool IsNet60Project(string fileContent, string fileExtenstion)
    {
        if (fileExtenstion != ".csproj")
            return false;

        if (!fileContent.Contains("<TargetFramework>net6.0</TargetFramework>"))
            return false;

        return true;
    }
}