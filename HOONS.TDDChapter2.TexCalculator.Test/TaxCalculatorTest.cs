using System;
using System.Runtime.Remoting.Messaging;
using NUnit.Framework;
using HOONS.TDD.Chapter2.TaxCalculator;

namespace HOONS.TDDChapter2.TaxCalculator.Test
{
public class StubTaxRepository : ITaxRepository
{
    public int TaxRate { get; set; }

    public int GetTaxRate(TaxYear taxYear)
    {
        return TaxRate;
    }

}
public class StubTaxRepositoryAbstract : ATaxRepository
{
    public int TaxRate { get; set; }
    public override int GetTaxRate(TaxYear taxYear)
    {
        return TaxRate;
    }

}

[TestFixture]
public class TaxCalculatorTest
{
    [Test]
    public void When2013_ShouldReturn90PercentUsingAbstractClass()
    {
        //Arrange
        var taxRepo = new StubTaxRepository { TaxRate = 10 };
        var taxHelper = new TaxHelper(TaxYear.Year2013, taxRepo);
        const int salaryExpected = 900;

        //Act
        var salaryResulted = taxHelper.Calculate(1000);

        //Assert
        Assert.That(salaryResulted, Is.EqualTo(salaryExpected));
    }

    [Test]
    public void When2013_ShouldReturn90Percent()
    {
        //Arrange
        var taxRepo = new StubTaxRepository {TaxRate = 10};
        var taxHelper = new TaxHelper(TaxYear.Year2013, taxRepo);
        const int salaryExpected = 900;

        //Act
        var salaryResulted = taxHelper.Calculate(1000);

        //Assert
        Assert.That(salaryResulted, Is.EqualTo(salaryExpected));
    }

    [Test]
    public void When2014_ShouldReturn80Percent()
    {
        //Arrange
        var taxRepo = new StubTaxRepository {TaxRate = 20};
        var taxHelper = new TaxHelper(TaxYear.Year2013, taxRepo);
        const int salaryExpected = 800;

        //Act
        var salaryResulted = taxHelper.Calculate(1000);

        //Assert
        Assert.That(salaryResulted, Is.EqualTo(salaryExpected));
    }

    [TestCase(TaxYear.Year2013)]
    [TestCase(TaxYear.Year2014)]
    public void WhenSalaryIsZero_ShouldReturnZero(TaxYear taxYear)
    {
        //Arrange
        var taxRepo = new StubTaxRepository {TaxRate = 10};
        var taxHelper = new TaxHelper(TaxYear.Year2013, taxRepo);
        const int salaryExpected = 0;

        //Act
        var salaryResulted = taxHelper.Calculate(0);

        //Assert
        Assert.That(salaryResulted, Is.EqualTo(salaryExpected));
    }
}
}
