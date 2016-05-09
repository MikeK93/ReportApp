using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using ReportApp.Infrastructure;
using ReportApp.Infrastructure.Abstaction;
using ReportApp.WebApp.Models;
using ReportApp.WebApp.Models.Helpers;
using ReportApp.WebApp.Services.Report;

namespace ReportAppWebApp.UnitTests
{
    [TestFixture]
    public class ReportServiceTests
    {
        private Mock<IRecordRepository> _recordRepositoryMock;
        private Mock<ITagRepository> _tagRepositoryMock;
        private Mock<IRecordValidator> _recordValidatorMock;
        private Mock<IReportConverter> _reportConverterMock;

        [SetUp]
        public void Init()
        {
            _recordRepositoryMock = new Mock<IRecordRepository>();
            _reportConverterMock = new Mock<IReportConverter>();
            _recordValidatorMock = new Mock<IRecordValidator>();
            _tagRepositoryMock = new Mock<ITagRepository>();
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
            var model = new RecordViewModel {Tags = new[] {new TagViewModel {Name = "<invalid tag>"}}};
            _recordValidatorMock.Setup(o => o.IsNameValid("<invalid tag>")).Returns(false);
            var target = GetService();

            //act & assert
            var actual = Assert.ThrowsAsync(typeof(ArgumentException), () => target.AppendRecordAsync(model));
            actual.Message.Should().Be("Invalid tag");
        }

        [Test]
        public async Task AppendRecordAsync_ShouldSaveNewTag_OnModelContainsNewTagThatDoesntExist()
        {
            //arrange
            var NOT_EXISTING_TAG = "not existing tag";
            var model = new RecordViewModel {Tags = new[] {new TagViewModel {Name = NOT_EXISTING_TAG, Id = 0}}};
            var target = GetService();

            //act
            await target.AppendRecordAsync(model);

            //assert
            _tagRepositoryMock.Verify(o => o.SaveAsync(It.IsAny<IEnumerable<Tag>>()), Times.Once);
        }

        [Test]
        public async Task AppendRecordAsync_ShouldSaveRecord()
        {
            //assert
            var target = GetService();
            var model = new RecordViewModel { Tags = new[] { new TagViewModel { Name = "some-tag" } } };
            _recordRepositoryMock.Setup(o => o.GetTagByNameAsync(It.IsAny<string>())).ReturnsAsync(new Tag());

            //act
            await target.AppendRecordAsync(model);

            //assert
            _recordRepositoryMock.Verify(o => o.SaveAsync(It.IsAny<Record>()), Times.Once);
        }

        public IReportService GetService()
        {
            return new ReportService(_recordRepositoryMock.Object, _reportConverterMock.Object, _recordValidatorMock.Object, _tagRepositoryMock.Object);
        }
    }
}
