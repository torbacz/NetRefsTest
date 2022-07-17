namespace NetProjTest.Exceptions;

public sealed class AdditionalFileFoundException : Exception
{
    internal AdditionalFileFoundException(string projectName, string fileName) : base(
        $"File {fileName} found in project {projectName}")
    {
    }
    
    internal  AdditionalFileFoundException(string projectName, string fileName, string link) : base(
        $"File {fileName} with link {link} found in project {projectName}")
    {
    }
}