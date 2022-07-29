using NetProjTest.Unit.Tests.BaseTests;

namespace NetProjTest.Unit.Tests.NetFramework;

public class SingleProjectFluentApiPackagesNetFrameworkTests : SingleProjectFluentApiPackagesTests
{
    protected override string SampleProjectPath => "TestSamples//NetFrameworkWithPackageAndFile//NetFrameworkWithPackageAndFile.csproj";
    protected override string ExistingPackage => "StyleCop.Analyzers";
    protected override string ExistingPackageVersion => "1.1.118";
    protected override string NoExistingPackage => "StyleCop.Analyzers1";
    protected override string NoExistingPackageVersion => "0.0.0.0";
}