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

        throw new NotSupportedException($"Requested project is not supported");
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