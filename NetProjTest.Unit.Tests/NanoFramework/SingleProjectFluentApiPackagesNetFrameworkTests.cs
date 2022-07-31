using NetProjTest.Unit.Tests.BaseTests;

namespace NetProjTest.Unit.Tests.NanoFramework;

public class SingleProjectFluentApiPackagesNanoFrameworkTests : SingleProjectFluentApiPackagesTests
{
    protected override string SampleProjectPath => "TestSamples/NanoFrameworkWIthPackageAndFile/NanoFrameworkWIthPackageAndFile.nfproj";
    protected override string ExistingPackage => "StyleCop.MSBuild";
    protected override string ExistingPackageVersion => "6.2.0";
    protected override string NoExistingPackage => "StyleCop.MSBuild1";
    protected override string NoExistingPackageVersion => "0.0.0.0";
}