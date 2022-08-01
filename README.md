# NetRefsTest
A fluent API for unit testing all sorts of .Net project files. 

Inspired by Inspired by the [NetArchTest](https://github.com/BenMorris/NetArchTest) and [FluentAssertions](https://github.com/fluentassertions/fluentassertions)

# Supported .Net versions

| Version | Supported |
|---------|-----------|
| .Net6   | Yes       |
| .netFramework   | Yes       |
| nanoFramework   | Yes       |

# Supported features
- Check if project has package reference
- Check if project has additional file included

# Code samples
## Validate the project file to see if it contains the package
```c#
var project = IProject.FromFile(ProjectPath);
project.Should().ContainPackage(PackageName);
project.Should().ContainPackage(PackageName, PackageVersion)
```

## Validate the projects in directory to see if it contains the package
```c#
var allFiles = IProjects.SearchFiles(SearchPath, "*.csproj", SearchOption.AllDirectories);
var projects = IProjects.FromFiles(allFiles);
projects.Should().ContainPackage(PackageName);
projects.Should().ContainPackage(PackageName, PackageVersion)
```