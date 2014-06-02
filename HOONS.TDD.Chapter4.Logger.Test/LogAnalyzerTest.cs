using System;
using HOONS.TDD.Chapter2.TaxCalculator;
using NUnit.Framework;
using Moq;

namespace HOONS.TDD.Chapter4.Logger.Test
{
    public class MockService : IWebService
    {
        public string LastError
        {
            get { return _lastError; }
        }

        private string _lastError;

        public void LogError(string message)
        {
            _lastError = message;
        }
    }


    [TestFixture]
    public class LogAnalyzerTest
    {

        [Test]
        public void WhenAnalyze_ShouldReturnTooShortFileName()
        {
            var mockService = new MockService();
            var log = new LogAnalyzer(mockService);
            string tooShortFileName = "abc.ext";

            log.Analyze(tooShortFileName);

            Assert.That(mockService.LastError, Is.EqualTo("Filename too short:abc.ext"));
        }

        [Test]
        public void When2013_ShouldReturn90Percent_UsingMoq()
        {
            //Arrange
            var taxRepo = new Mock<ITaxRepository>();
            taxRepo.Setup(x => x.GetTaxRate(It.IsAny<TaxYear>())).Returns(10);
            var taxHelper = new TaxHelper(TaxYear.Year2013, taxRepo.Object);
            const int salaryExpected = 900;

            //Act
            var salaryResulted = taxHelper.Calculate(1000);

            //Assert
            Assert.That(salaryResulted, Is.EqualTo(salaryExpected));
        }


        [Test]
        public void WhenAnalyze_ShouldReturnTooShortFileName_WithMock()
        {
            var mockService = new Mock<IWebService>(MockBehavior.Strict);

            string tooShortFileName = "abc.ext";
            mockService.Setup(x => x.LogError("Filename too short:abc.ext")).Verifiable();

            var log = new LogAnalyzer(mockService.Object);

            log.Analyze(tooShortFileName);

            //Assert.That(strLastError, Is.EqualTo("Filename too short:abc.ext"));
            mockService.Verify(x => x.LogError("Filename too short:abc.ext"));
            //mockService.Verify(x => x.LogError(It.IsAny<string>()));
        }

        [Test]
        //[ExpectedException]
        public void WhenAnalyze_ShouldReturnTooShortFileName_WithCallback()
        {
            //Arrange
            var mockService = new Mock<IWebService>(MockBehavior.Strict);
            string strLastError = "";
            string tooShortFileName = "abc.ext";

            mockService.Setup(x => x.LogError(It.IsAny<string>(
                )))
                .Callback(
                    (string error) =>
                    {
                        strLastError = error;
                    }
                );
            //mockService.Setup(x => x.LogError("Tsest")).Throws(new ArgumentException());
            var log = new LogAnalyzer(mockService.Object);

            //Act
            log.Analyze(tooShortFileName);

            //Assert
            Assert.That(strLastError, Is.EqualTo("Filename too short:abc.ext"));
        }
    }
}