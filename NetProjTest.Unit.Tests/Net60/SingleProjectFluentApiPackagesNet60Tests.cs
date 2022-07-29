using NetProjTest.Unit.Tests.BaseTests;

namespace NetProjTest.Unit.Tests.Net60;

public class SingleProjectFluentApiPackagesPackagesNet60Tests : SingleProjectFluentApiPackagesTests
{
    protected override string SampleProjectPath => "TestSamples\\Net60WithPackageAndFile.csproj";
    protected override string ExistingPackage => "StyleCop.Analyzers";
    protected override string NoExistingPackage => "StyleCop.Analyzers1";
    protected override string ExistingPackageVersion => "1.2.0-beta.435";
    protected override string NoExistingPackageVersion => "1.2.0-beta.430";
}