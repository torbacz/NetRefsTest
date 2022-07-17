using NetProjTest.FluentInterfaces;

namespace NetProjTest;

public interface IProjects
{
    public static IProjects FromFiles(IEnumerable<string> files)
    {
        var projectsList = new List<IProject>();
        foreach (var projectPath in files)
            projectsList.Add(IProject.FromFile(projectPath));

        return new ProjectsTester(projectsList);
    }

    public static IEnumerable<string> SearchFiles(string directoryPath, string searchPattern, SearchOption searchOption)
    {
        return Directory.EnumerateFiles(directoryPath, searchPattern, searchOption);
    } 

    public IShould<IProjects> Should();
}