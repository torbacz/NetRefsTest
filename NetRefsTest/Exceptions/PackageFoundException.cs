﻿namespace NetRefsTest.Exceptions;

public sealed class PackageFoundException : Exception
{
    public PackageFoundException(string projectName, string packageName) : base(
        $"Package {packageName} found in project {projectName}")
    {
    }
    
    public PackageFoundException(string projectName, string packageName, string version) : base(
        $"Package {packageName} version {version} found in project {projectName}")
    {
    }
}