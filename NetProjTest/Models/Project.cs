using System.Text.RegularExpressions;
using NetProjTest.Models.Net60;
using NetProjTest.Models.NetFramework;

namespace NetProjTest.Models;

internal class Project
{
    private Project(string projectName, TargetFramework targetFramework, IReadOnlyList<Package> packages, IReadOnlyList<File> files)
    {
        ProjectName = projectName;
        TargetFramework = targetFramework;
        Packages = packages;
        Files = files;
    }

    public string ProjectName { get; }
    public TargetFramework TargetFramework { get; }
    public IReadOnlyList<Package> Packages { get; }
    public IReadOnlyList<File> Files { get; }
    //TODO: Add references

    internal static Project FromNet60Project(Net60Project project)
    {
        if (project == null) 
            throw new ArgumentNullException(nameof(project));
        
        if (string.IsNullOrEmpty(project.ProjectName)) 
            throw new ArgumentNullException(nameof(project.ProjectName));

        var packages = project.ItemGroups?.Where(x => x.PackageReferences != null).SelectMany(x =>
                x.PackageReferences ?? throw new ArgumentNullException(nameof(x.PackageReferences)))
            .Select(x => new Package(x.Include ?? string.Empty, x.Version ?? string.Empty)).ToList();

        var files = project.ItemGroups?.Where(x => x.AdditionalFiless != null).SelectMany(x =>
                x.AdditionalFiless ?? throw new ArgumentNullException(nameof(x.AdditionalFiless)))
            .Select(x => new File() { FileName = x.Link ?? string.Empty, FilePath = x.Include ?? string.Empty })
            .ToList();

        return new Project(project.ProjectName, TargetFramework.Net60, packages ?? new List<Package>(),
            files ?? new List<File>());
    }

    private static string GetPackageNameFromNetFrameworkProject(string input)
    {
        var regex = new Regex("^([^,]+)");
        return regex.Match(input).Value;
    }

    private static string GetPackageVersionFromNetFrameworkProject(string input)
    {
        var regex = new Regex("([^,]+)");
        var matches = regex.Matches(input);
        if (matches.Count() == 1)
            return string.Empty;

        return regex.Matches(input)[1].Value.Replace("Version=", "").Trim();
    }
    
    internal static Project FromNetFrameworkProject(NetFrameworkProject project)
    {
        if (project == null) 
            throw new ArgumentNullException(nameof(project));
        
        if (string.IsNullOrEmpty(project.ProjectName)) 
            throw new ArgumentNullException(nameof(project.ProjectName));

        /* References
         * project.ItemGroups?.Where(x => x.References != null).SelectMany(x =>
                x.References ?? throw new ArgumentNullException(nameof(x.References)))
            .Select(x => new Package(GetPackageNameFromNetFrameworkProject(x.Include),
                GetPackageVersionFromNetFrameworkProject(x.Include))).ToList(); //TODO: from packages 
         */

        var packages = project.Packages.Select(x => new Package(x.Id, x.Version)).ToList(); 
        
        var contentFiles = project.ItemGroups?.Where(x => x.ContentFiles != null)
            .SelectMany(x => x.ContentFiles ?? throw new ArgumentNullException(nameof(x.ContentFiles)))
            .Select(x => new File() { FilePath = x.Include, FileName = Path.GetFileName(x.Include) }).ToList();

        return new Project(project.ProjectName, TargetFramework.NetFramework, packages, contentFiles);
    }
}