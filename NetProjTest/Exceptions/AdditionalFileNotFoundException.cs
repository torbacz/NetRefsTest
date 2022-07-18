namespace NetProjTest.Exceptions;

public sealed class AdditionalFileNotFoundException : Exception
{
    internal AdditionalFileNotFoundException(string projectName, string fileName) : base(
        $"File {fileName} not found in project {projectName}")
    {
    }
    
    internal  AdditionalFileNotFoundException(string projectName, string fileName, string link) : base(
        $"File {fileName} with link {link} not found in project {projectName}")
    {
    }
}