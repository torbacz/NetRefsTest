using NetProjTest.Exceptions;
using Moq;
using NetProjTest.FluentInterfaces;
using NetProjTest.Models;
using NetProjTest.Models.Net60;

namespace NetProjTest.Unit.Tests;

public class MultipleProjectsFluentApiTests
{

    IEnumerable<Mock<IProject>> GetListOfProjects()
    {
        yield return new Mock<IProject>();
        yield return new Mock<IProject>();
        yield return new Mock<IProject>();
    }

    IEnumerable<Mock<IProject>> GetListOfMockedProjects()
    {
        foreach (var project in GetListOfProjects())
        {
            var shouldMock = new Mock<IShould<IProject>>();
            project.Setup(x => x.Should()).Returns(shouldMock.Object);
            
            var shouldNotMock = new Mock<IShouldNot<IProject>>();
            project.Setup(x => x.Should().Not()).Returns(shouldNotMock.Object);
            
            yield return project;
        }
    }


    [Fact]
    public void ShouldContainPackage_Should_CallAllProjects()
    {
        var projectMocksList = GetListOfMockedProjects().ToList();
        var projectList = projectMocksList.Select(x => x.Object).ToList();
        var projects = (new ProjectsTester(projectList)).As<IProjects>();
        var packageName = "test";

        projects.Should().ContainPackage(packageName);

        foreach (var mock in projectMocksList)
            mock.Verify(x => x.Should().ContainPackage(packageName));
    }
    
    [Fact]
    public void ShouldContainPackageWithLink_Should_CallAllProjects()
    {
        var projectMocksList = GetListOfMockedProjects().ToList();
        var projectList = projectMocksList.Select(x => x.Object).ToList();
        var projects = (new ProjectsTester(projectList)).As<IProjects>();
        var packageName = "test";
        var link = "test2";

        projects.Should().ContainPackage(packageName, link);

        foreach (var mock in projectMocksList)
            mock.Verify(x => x.Should().ContainPackage(packageName, link));
    }
    
    [Fact]
    public void ShouldContainFile_Should_CallAllProjects()
    {
        var projectMocksList = GetListOfMockedProjects().ToList();
        var projectList = projectMocksList.Select(x => x.Object).ToList();
        var projects = (new ProjectsTester(projectList)).As<IProjects>();
        var fileName = "test";

        projects.Should().ContainFile(fileName);

        foreach (var mock in projectMocksList)
            mock.Verify(x => x.Should().ContainFile(fileName));
    }
    
    [Fact]
    public void ShouldContainFileWithPath_Should_CallAllProjects()
    {
        var projectMocksList = GetListOfMockedProjects().ToList();
        var projectList = projectMocksList.Select(x => x.Object).ToList();
        var projects = (new ProjectsTester(projectList)).As<IProjects>();
        var fileName = "test";
        var filePath = "test2";

        projects.Should().ContainFile(fileName, filePath);

        foreach (var mock in projectMocksList)
            mock.Verify(x => x.Should().ContainFile(fileName, filePath));
    }
    
    [Fact]
    public void ShouldTargetFramework_Should_CallAllProjects()
    {
        var projectMocksList = GetListOfMockedProjects().ToList();
        var projectList = projectMocksList.Select(x => x.Object).ToList();
        var projects = (new ProjectsTester(projectList)).As<IProjects>();
        var targetFramework = TargetFramework.Net60;

        projects.Should().TargetFramework(targetFramework);

        foreach (var mock in projectMocksList)
            mock.Verify(x => x.Should().TargetFramework(targetFramework));
    }
    
    [Fact]
    public void ShouldNotContainPackage_Should_CallAllProjects()
    {
        var projectMocksList = GetListOfMockedProjects().ToList();
        var projectList = projectMocksList.Select(x => x.Object).ToList();
        var projects = (new ProjectsTester(projectList)).As<IProjects>();
        var packageName = "test";

        projects.Should().Not().ContainPackage(packageName);

        foreach (var mock in projectMocksList)
            mock.Verify(x => x.Should().Not().ContainPackage(packageName));
    }
    
    [Fact]
    public void ShouldNotContainPackageWithLink_Should_CallAllProjects()
    {
        var projectMocksList = GetListOfMockedProjects().ToList();
        var projectList = projectMocksList.Select(x => x.Object).ToList();
        var projects = (new ProjectsTester(projectList)).As<IProjects>();
        var packageName = "test";
        var link = "test2";

        projects.Should().Not().ContainPackage(packageName, link);

        foreach (var mock in projectMocksList)
            mock.Verify(x => x.Should().Not().ContainPackage(packageName, link));
    }
    
    [Fact]
    public void ShouldNotContainFile_Should_CallAllProjects()
    {
        var projectMocksList = GetListOfMockedProjects().ToList();
        var projectList = projectMocksList.Select(x => x.Object).ToList();
        var projects = (new ProjectsTester(projectList)).As<IProjects>();
        var fileName = "test";

        projects.Should().Not().ContainFile(fileName);

        foreach (var mock in projectMocksList)
            mock.Verify(x => x.Should().Not().ContainFile(fileName));
    }
    
    [Fact]
    public void ShouldNotContainFileWithPath_Should_CallAllProjects()
    {
        var projectMocksList = GetListOfMockedProjects().ToList();
        var projectList = projectMocksList.Select(x => x.Object).ToList();
        var projects = (new ProjectsTester(projectList)).As<IProjects>();
        var fileName = "test";
        var filePath = "test2";

        projects.Should().Not().ContainFile(fileName, filePath);

        foreach (var mock in projectMocksList)
            mock.Verify(x => x.Should().Not().ContainFile(fileName, filePath));
    }
    
    [Fact]
    public void ShouldNotTargetFramework_Should_CallAllProjects()
    {
        var projectMocksList = GetListOfMockedProjects().ToList();
        var projectList = projectMocksList.Select(x => x.Object).ToList();
        var projects = (new ProjectsTester(projectList)).As<IProjects>();
        var targetFramework = TargetFramework.Net60;

        projects.Should().Not().TargetFramework(targetFramework);

        foreach (var mock in projectMocksList)
            mock.Verify(x => x.Should().Not().TargetFramework(targetFramework));
    }

}