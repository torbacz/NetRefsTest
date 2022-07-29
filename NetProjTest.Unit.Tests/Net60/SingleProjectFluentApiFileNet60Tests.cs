using NetProjTest.Unit.Tests.BaseTests;

namespace NetProjTest.Unit.Tests.Net60;

public class SingleProjectFluentApiFileNet60Tests : SingleProjectFluentApiFromFilesTests
{
    protected override string SampleProjectName => $"Net60WithPackageAndFile";
    protected override string ExistingFileName => "stylecop.json";
    protected override string NoExistingFileName => "stylecop1.json";
    protected override string ExistingFilePath => "..\\stylecop.json";
    protected override string NoExistingFilePath => "testPath";
}