using NetProjTest.Models;
using NetProjTest.Models.Net60;

namespace NetProjTest.Unit.Tests;

public class ProjectSerializationTests
{
    [Fact]
    public void Project_Should_SerializeSuccessfullyFromString()
    {
        var projectName = "testProject";
        var project = Net60Project.FromXmlString(ProjectSamples.testProjectNet60_1, projectName);

        project.ProjectName.Should().Be(projectName);
        project.Sdk.Should().Be("Microsoft.NET.Sdk");
        project.ItemGroups.Count.Should().Be(2);
        project.PropertyGroups.Count.Should().Be(3);
        
        project.PropertyGroups[0].CheckForOverflowUnderflowRaw.Should().BeNull();
        project.PropertyGroups[0].CheckForOverflowUnderflow.Should().BeFalse();
        project.PropertyGroups[0].Condition.Should().BeNull();
        project.PropertyGroups[0].GenerateDocumentationFileRaw.Should().Be("True");
        project.PropertyGroups[0].GenerateDocumentationFile.Should().BeTrue();
        project.PropertyGroups[0].ImplicitUsingsRaw.Should().Be("enable");
        project.PropertyGroups[0].ImplicitUsings.Should().BeTrue();
        project.PropertyGroups[0].IsPackableRaw.Should().BeNull();
        project.PropertyGroups[0].IsPackable.Should().BeFalse();
        project.PropertyGroups[0].TargetFrameworkRaw.Should().Be("net6.0");
        project.PropertyGroups[0].TargetFramework.Should().Be(TargetFramework.Net60);
        project.PropertyGroups[0].TreatWarningsAsErrorsRaw.Should().Be("true");
        project.PropertyGroups[0].TreatWarningsAsErrors.Should().BeTrue();
        
        project.PropertyGroups[1].CheckForOverflowUnderflowRaw.Should().Be("True");
        project.PropertyGroups[1].CheckForOverflowUnderflow.Should().BeTrue();
        project.PropertyGroups[1].Condition.Should().Be("'$(Configuration)|$(Platform)'=='Debug|AnyCPU'");
        project.PropertyGroups[1].GenerateDocumentationFileRaw.Should().BeNull();
        project.PropertyGroups[1].GenerateDocumentationFile.Should().BeFalse();
        project.PropertyGroups[1].ImplicitUsingsRaw.Should().BeNull();
        project.PropertyGroups[1].ImplicitUsings.Should().BeFalse();
        project.PropertyGroups[1].IsPackableRaw.Should().BeNull();
        project.PropertyGroups[1].IsPackable.Should().BeFalse();
        project.PropertyGroups[1].TargetFrameworkRaw.Should().BeNull();
        project.PropertyGroups[1].TargetFramework.Should().BeNull();
        project.PropertyGroups[1].TreatWarningsAsErrorsRaw.Should().BeNull();
        project.PropertyGroups[1].TreatWarningsAsErrors.Should().BeFalse();
        
        project.PropertyGroups[2].CheckForOverflowUnderflowRaw.Should().Be("True");
        project.PropertyGroups[2].CheckForOverflowUnderflow.Should().BeTrue();
        project.PropertyGroups[2].Condition.Should().Be("'$(Configuration)|$(Platform)'=='Release|AnyCPU'");
        project.PropertyGroups[2].GenerateDocumentationFileRaw.Should().BeNull();
        project.PropertyGroups[2].GenerateDocumentationFile.Should().BeFalse();
        project.PropertyGroups[2].ImplicitUsingsRaw.Should().BeNull();
        project.PropertyGroups[2].ImplicitUsings.Should().BeFalse();
        project.PropertyGroups[2].IsPackableRaw.Should().BeNull();
        project.PropertyGroups[2].IsPackable.Should().BeFalse();
        project.PropertyGroups[2].TargetFrameworkRaw.Should().BeNull();
        project.PropertyGroups[2].TargetFramework.Should().BeNull();
        project.PropertyGroups[2].TreatWarningsAsErrorsRaw.Should().BeNull();
        project.PropertyGroups[2].TreatWarningsAsErrors.Should().BeFalse();
        
        project.ItemGroups[0].AdditionalFiless.Count.Should().Be(0);
        project.ItemGroups[0].PackageReferences.Count.Should().Be(1);
        project.ItemGroups[0].PackageReferences[0].Include.Should().Be("StyleCop.Analyzers");
        project.ItemGroups[0].PackageReferences[0].IncludeAssets.Should().Be("runtime; build; native; contentfiles; analyzers; buildtransitive");
        project.ItemGroups[0].PackageReferences[0].PrivateAssets.Should().Be("all");
        project.ItemGroups[0].PackageReferences[0].Version.Should().Be("1.2.0-beta.435");
        
        project.ItemGroups[1].AdditionalFiless.Count.Should().Be(1);
        project.ItemGroups[1].PackageReferences.Count.Should().Be(0);
        project.ItemGroups[1].AdditionalFiless[0].Include.Should().Be("..\\stylecop.json");
        project.ItemGroups[1].AdditionalFiless[0].Link.Should().Be("stylecop.json");
    }

    [Fact]
    public void Project_Should_SerializeSuccessfullyFromFile()
    {
        const string path = "../../../NetProjTest.Unit.Tests.csproj";

        var project = Net60Project.FromFile(path);

        project.Should().NotBeNull();
    }
}