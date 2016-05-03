using System;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using ReportApp.API.RecordRepository;
using ReportApp.Models;
using ReportApp.Models.Helpers;
using ReportApp.WebApp.Models.Helpers;
using ReportApp.WebApp.Services.Report;

namespace ReportAppWebApp.UnitTests
{
    [TestFixture]
    public class ReportServiceTests
    {
        private Mock<IRecordRepository> _recordRepositoryMock;
        private Mock<IReportConverter> _reportConverterMock;
        private Mock<IRecordValidator> _recordValidatorMock;

        [SetUp]
        public void Init()
        {
            _recordRepositoryMock = new Mock<IRecordRepository>();
            _recordValidatorMock = new Mock<IRecordValidator>();
            _reportConverterMock = new Mock<IReportConverter>();
        }

        [Test]
        public async Task AppendRecord_ShouldThrow_OnModelWithInvalidDescription()
        {
            //arrange
            var target = new ReportService(_recordRepositoryMock.Object, _reportConverterMock.Object, _recordValidatorMock.Object);
            var invalidModel = new RecordViewModel { Description = "<script>" };

            //act
            Assert.ThrowsAsync<ArgumentException>(() => target.AppendRecordAsync(invalidModel));
        }
    }
}
