﻿using NetProjTest.Models;
using NetProjTest.Models.Net60;
using NetProjTest.Unit.Tests.BaseTests;

namespace NetProjTest.Unit.Tests.NetFramework;

public class SingleProjectFluentApiTargetFrameworkNetFrameworkTests: SingleProjectFluentApiTargetFrameworkTests
{
    protected override string SampleProjectPath => "TestSamples/NetFrameworkWithPackageAndFile/NetFrameworkWithPackageAndFile.csproj";
    public override TargetFramework TargetFramework => TargetFramework.NetFramework;
}