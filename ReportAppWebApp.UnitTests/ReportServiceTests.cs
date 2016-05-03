using System;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using ReportApp.API;
using ReportApp.API.RecordRepository;
using ReportApp.Models;
using ReportApp.WebApp.Models.Helpers;
using ReportApp.WebApp.Services.Report;

namespace ReportAppWebApp.UnitTests
{
    [TestFixture]
    public class ReportServiceTests
    {
        private Mock<IRecordRepository> _recordRepositoryMock;
        private Mock<IRecordValidator> _recordValidatorMock;
        private Mock<IReportConverter> _reportConverterMock;

        [SetUp]
        public void Init()
        {
            _recordRepositoryMock = new Mock<IRecordRepository>();
            _reportConverterMock = new Mock<IReportConverter>();
            _recordValidatorMock = new Mock<IRecordValidator>();
            _recordValidatorMock.Setup(o => o.IsNameValid(It.IsAny<string>())).Returns(true);
            _recordValidatorMock.Setup(o => o.IsDescriptionValid(It.IsAny<string>())).Returns(true);
        }

        [Test]
        public async Task AppendRecordAsync_ShouldThrow_OnModelWithInvalidDescription()
        {
            //arrange
            var model = new RecordViewModel { Description = "<script>" };
            _recordValidatorMock.Setup(o => o.IsDescriptionValid(It.IsAny<string>())).Returns(false);
            var target = GetService();

            //act & assert
            var actual = Assert.ThrowsAsync(typeof(ArgumentException), () => target.AppendRecordAsync(model));
            actual.Message.Should().Be("Invalid description: <script>");
        }

        [Test]
        public async Task AppendRecordAsync_ShouldThrow_OnModelWithInvalidTitle()
        {
            //arrange
            var model = new RecordViewModel { Title = "<script>" };
            _recordValidatorMock.Setup(o => o.IsNameValid(It.IsAny<string>())).Returns(false);
            var target = GetService();

            //act & assert
            var actual = Assert.ThrowsAsync(typeof(ArgumentException), () => target.AppendRecordAsync(model));
            actual.Message.Should().Be("Invalid title: <script>");
        }

        [Test]
        public async Task AppendRecordAsync_ShouldThrow_OnModelContainsInvalidTags()
        {
            //arrange
            var model = new RecordViewModel { Tags = new[] { "<invalid tag>" } };
            _recordValidatorMock.Setup(o => o.IsNameValid("<invalid tag>")).Returns(false);
            var target = GetService();

            //act & assert
            var actual = Assert.ThrowsAsync(typeof(ArgumentException), () => target.AppendRecordAsync(model));
            actual.Message.Should().Be("Invalid tag");
        }

        [Test]
        public async Task AppendRecordAsync_ShouldThrow_OnModelContainsTagThatDoesntExist()
        {
            //arrange
            var NOT_EXISTING_TAG = "not existing tag";
            var model = new RecordViewModel { Tags = new[] { NOT_EXISTING_TAG } };
            _recordRepositoryMock.Setup(o => o.GetTagByNameAsync(NOT_EXISTING_TAG)).ReturnsAsync(null);
            var target = GetService();

            //act & assert
            var actual = Assert.ThrowsAsync(typeof(ArgumentException), () => target.AppendRecordAsync(model));
            actual.Message.Should().Be("Tag does not exist");
        }

        [Test]
        public async Task AppendRecordAsync_ShouldSaveRecord()
        {
            //assert
            var target = GetService();
            var model = new RecordViewModel { Tags = new[] { "some-tag" } };
            _recordRepositoryMock.Setup(o => o.GetTagByNameAsync(It.IsAny<string>())).ReturnsAsync(new Tag());

            //act
            await target.AppendRecordAsync(model);

            //assert
            _recordRepositoryMock.Verify(o => o.SaveAsync(It.IsAny<Record>()), Times.Once);
        }

        public IReportService GetService()
        {
            return new ReportService(_recordRepositoryMock.Object, _reportConverterMock.Object, _recordValidatorMock.Object);
        }
    }
}
