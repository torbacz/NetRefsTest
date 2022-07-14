namespace NetProjTest.Exceptions;

public sealed class AdditionalFileNotFoundException : Exception
{
    public AdditionalFileNotFoundException(string projectName, string fileName) : base(
        $"File {fileName} not found in project {projectName}")
    {
    }
    
    public AdditionalFileNotFoundException(string projectName, string fileName, string link) : base(
        $"File {fileName} with link {link} not found in project {projectName}")
    {
    }
}