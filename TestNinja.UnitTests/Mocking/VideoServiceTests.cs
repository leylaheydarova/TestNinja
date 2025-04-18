using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        VideoService _videoService;
        Mock<IFileReader> _mockFileReader;


        [SetUp]
        public void Setup()
        {
            _mockFileReader = new Mock<IFileReader>();
            _videoService = new VideoService(_mockFileReader.Object);
        }
        [Test]
        public void ReadVideoTitle_WhenEmptyFile_ShouldReturnErrorMessage()
        {
            _mockFileReader.Setup(fr => fr.ReadFile("video.txt")).Returns("");
            var title = _videoService.ReadVideoTitle();
            Assert.That(title, Does.Contain("error").IgnoreCase);
        }
    }
}
