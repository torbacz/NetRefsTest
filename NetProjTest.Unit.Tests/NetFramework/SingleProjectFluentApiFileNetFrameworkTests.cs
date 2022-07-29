using NetProjTest.Unit.Tests.BaseTests;

namespace NetProjTest.Unit.Tests.NetFramework;

public class SingleProjectFluentApiFileNetFrameworkTests : SingleProjectFluentApiFromFilesTests
{
    protected override string SampleProjectPath => "TestSamples\\NetFrameworkWithPackageAndFile\\NetFrameworkWithPackageAndFile.csproj";
    protected override string ExistingFileName => "test.txt";
    protected override string NoExistingFileName => "test1.txt";
    protected override string ExistingFilePath => "Test\\test.txt";
    protected override string NoExistingFilePath => "Test\\test1.txt";
}