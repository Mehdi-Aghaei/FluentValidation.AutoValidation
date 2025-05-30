﻿using System;
using Microsoft.AspNetCore.Mvc;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Attributes;
using SharpGrip.FluentValidation.AutoValidation.Shared.Extensions;
using Xunit;

namespace SharpGrip.FluentValidation.AutoValidation.Tests.FluentValidation.AutoValidation.Shared.Extensions;

public class TypeExtensionsTest
{
    [Fact]
    public void Test_IsCustomType()
    {
        Assert.True(typeof(TestModelClass).IsCustomType());
        Assert.True(typeof(TestModelRecord).IsCustomType());
        Assert.False(typeof(TestModelEnum).IsCustomType());
        Assert.False(typeof(Enum).IsCustomType());
        Assert.False(typeof(string).IsCustomType());
        Assert.False(typeof(char).IsCustomType());
        Assert.False(typeof(short).IsCustomType());
        Assert.False(typeof(ushort).IsCustomType());
        Assert.False(typeof(int).IsCustomType());
        Assert.False(typeof(uint).IsCustomType());
        Assert.False(typeof(nint).IsCustomType());
        Assert.False(typeof(nuint).IsCustomType());
        Assert.False(typeof(long).IsCustomType());
        Assert.False(typeof(ulong).IsCustomType());
        Assert.False(typeof(double).IsCustomType());
        Assert.False(typeof(float).IsCustomType());
        Assert.False(typeof(decimal).IsCustomType());
        Assert.False(typeof(byte).IsCustomType());
        Assert.False(typeof(sbyte).IsCustomType());
        Assert.False(typeof(DateTime).IsCustomType());
        Assert.False(typeof(DateTimeOffset).IsCustomType());
        Assert.False(typeof(TimeSpan).IsCustomType());
        Assert.False(typeof(Guid).IsCustomType());
        Assert.False(typeof(DateOnly).IsCustomType());
        Assert.False(typeof(TimeOnly).IsCustomType());
    }

    [Fact]
    public void Test_HasCustomAttribute()
    {
        Assert.True(typeof(TestModelClass).HasCustomAttribute<AutoValidationAttribute>());
        Assert.False(typeof(TestModelClass).HasCustomAttribute<AutoValidateNeverAttribute>());
        Assert.True(typeof(TestModelRecord).HasCustomAttribute<AutoValidateNeverAttribute>());
        Assert.False(typeof(TestModelRecord).HasCustomAttribute<AutoValidationAttribute>());
    }

    [Fact]
    public void Test_InheritsFromTypeWithNameEndingIn()
    {
        Assert.True(typeof(TestInherits1).InheritsFromTypeWithNameEndingIn("Controller"));
        Assert.True(typeof(TestInherits1).InheritsFromTypeWithNameEndingIn("controller"));
        Assert.True(typeof(TestInherits2).InheritsFromTypeWithNameEndingIn("Controller"));
        Assert.True(typeof(TestInherits2).InheritsFromTypeWithNameEndingIn("controller"));
        Assert.False(typeof(TestInherits3).InheritsFromTypeWithNameEndingIn("Controller"));
        Assert.False(typeof(TestInherits3).InheritsFromTypeWithNameEndingIn("controller"));
        Assert.False(typeof(TestInherits4).InheritsFromTypeWithNameEndingIn("Controller"));
        Assert.False(typeof(TestInherits4).InheritsFromTypeWithNameEndingIn("controller"));
        Assert.False(typeof(TestInherits5).InheritsFromTypeWithNameEndingIn("Controller"));
        Assert.False(typeof(TestInherits5).InheritsFromTypeWithNameEndingIn("controller"));
    }

    [AutoValidation]
    private class TestModelClass;

    [AutoValidateNever]
    private record TestModelRecord;

    private enum TestModelEnum;

    private class TestInherits1 : Controller;

    private class TestInherits2 : CustomControllerBase;

    private class TestInherits3 : ControllerBase;

    private class TestInherits4 : ActionContext;

    private class TestInherits5 : object;

    private class CustomControllerBase : Controller;
}