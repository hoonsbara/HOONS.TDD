using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HOONS.TDD.Chapter1.SampleExample.Test
{

[TestClass]
public class MultipleCalculatorTest
{
    [TestMethod]
    public void WhenValueDivisibleOnlyBy3()
    {
        var mCal = new MultipleCalculator();
        string valueExpected = "Joel";
        string result = mCal.Calculate(3);
        Assert.AreEqual(valueExpected, result);
    }
    [TestMethod]
    public void WhenValueDivisibleOnlyBy7()
    {
        var mCal = new MultipleCalculator();
        string valueExpected = "Noah";
        string result = mCal.Calculate(7);
        Assert.AreEqual(valueExpected, result);
    }
    [TestMethod]
    public void WhenValueDivisibleOnlyBy5()
    {
        var mCal = new MultipleCalculator();
        string valueExpected = "Sarah";
        string result = mCal.Calculate(5);
        Assert.AreEqual(valueExpected, result);
    }

    [TestMethod]
    public void WhenValueDivisionBy3and5()
    {
        var mCal = new MultipleCalculator();
        string valueExpected = "Joel Sarah";
        string result = mCal.Calculate(15);
        Assert.AreEqual(valueExpected, result);
    }
    [TestMethod]
    public void WhenValueIsNotDivisibleBy3Or5()
    {
        var mCal = new MultipleCalculator();
        string valueExpected = "4";
        string result = mCal.Calculate(4);
        Assert.AreEqual(valueExpected, result);
    }
}
}

