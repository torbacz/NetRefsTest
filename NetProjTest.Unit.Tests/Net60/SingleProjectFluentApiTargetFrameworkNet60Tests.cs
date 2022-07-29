using NetProjTest.Models;
using NetProjTest.Models.Net60;
using NetProjTest.Unit.Tests.BaseTests;

namespace NetProjTest.Unit.Tests.Net60;

public class SingleProjectFluentApiTargetFrameworkNet60Tests : SingleProjectFluentApiTargetFrameworkTests
{
    protected override string SampleProjectPath => "TestSamples\\Net60WithPackageAndFile.csproj";
    public override TargetFramework TargetFramework => TargetFramework.Net60;
}