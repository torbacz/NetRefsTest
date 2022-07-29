using NetProjTest.Unit.Tests.BaseTests;

namespace NetProjTest.Unit.Tests.NetFramework;

public class SingleProjectFluentApiPackagesNetFrameworkTests : SingleProjectFluentApiPackagesTests
{
    protected override string SampleProjectName => "NetFrameworkWithPackageAndFile";
    protected override string ExistingPackage => "Newtonsoft.Json";
    protected override string ExistingPackageVersion => "13.0.0.0";
    protected override string NoExistingPackage => "Newtonsoft.Json1";
    protected override string NoExistingPackageVersion => "0.0.0.0";
}