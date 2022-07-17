using NetProjTest.Models.Net60;

namespace NetProjTest.Exceptions;

public sealed class InvalidTargetFrameworkException : Exception
{
    internal InvalidTargetFrameworkException(string projectName, TargetFramework currentTargetFramework,
        TargetFramework targetFramework) : base(
        $"Project {projectName} is targeting wrong version of framework. Should be {currentTargetFramework} instead of {targetFramework}.")
    {
    }
    
    internal InvalidTargetFrameworkException(string projectName, TargetFramework currentTargetFramework) : base(
        $"Project {projectName} is targeting wrong version of framework. Should not be {currentTargetFramework}.")
    {
    }
}