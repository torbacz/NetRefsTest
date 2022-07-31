using NetProjTest.Models;
using NetProjTest.Unit.Tests.BaseTests;

namespace NetProjTest.Unit.Tests.NanoFramework;

public class SingleProjectFluentApiTargetFrameworkNanoFrameworkTests: SingleProjectFluentApiTargetFrameworkTests
{
    protected override string SampleProjectPath => "TestSamples/NanoFrameworkWIthPackageAndFile/NanoFrameworkWIthPackageAndFile.nfproj";
    public override TargetFramework TargetFramework => TargetFramework.NanoFramework;
}