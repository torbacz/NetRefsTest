using NetProjTest.Models.Net60;

namespace NetProjTest.Models;

public class Project
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
}