using NetProjTest.Unit.Tests.BaseTests;

namespace NetProjTest.Unit.Tests.NanoFramework;

public class SingleProjectFluentApiFileNanoFrameworkTests : SingleProjectFluentApiFromFilesTests
{
    protected override string SampleProjectPath => "TestSamples/NanoFrameworkWIthPackageAndFile/NanoFrameworkWIthPackageAndFile.nfproj";
    protected override string ExistingFileName => "Settings.StyleCop";
    protected override string NoExistingFileName => "test1.txt";
    protected override string ExistingFilePath => "Settings.StyleCop";
    protected override string NoExistingFilePath => "Test/test1.txt";
}