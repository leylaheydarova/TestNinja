using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TestNinja.Mocking;
using TestNinja.Mocking.ExtractingMethods;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        VideoService _videoService;
        Mock<IFileReader> _mockFileReader;
        Mock<IVideoRepository> _mockRepository;


        [SetUp]
        public void Setup()
        {
            _mockFileReader = new Mock<IFileReader>();
            _mockRepository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_mockFileReader.Object, _mockRepository.Object);
        }
        [Test]
        public void ReadVideoTitle_WhenEmptyFile_ShouldReturnErrorMessage()
        {
            _mockFileReader.Setup(fr => fr.ReadFile("video.txt")).Returns("");
            var title = _videoService.ReadVideoTitle();
            Assert.That(title, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void ReadVideoTitle_WhenCalled_ShouldReturnVideoTitle()
        {
            _mockFileReader.Setup(fr => fr.ReadFile("video.txt")).Returns("{\"Title\": \"My Awesome Video\"}");
            var title = _videoService.ReadVideoTitle();
            Assert.That(title, Is.EqualTo("My Awesome Video").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_WhenAllVideosAreProcessed_ShouldReturnEmptyStrig()
        {
            _mockRepository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>());
            var videosIds = _videoService.GetUnprocessedVideosAsCsv();
            Assert.That(videosIds, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_WhenThereAreUnprocessedVides_ShouldReturnVideoIdsAsString()
        {
            var videos = new List<Video>()
            {
                { new Video{ Id = 1, Title = "FirstVideo", IsProcessed = false}},
                { new Video{ Id = 2, Title = "SecondVideo", IsProcessed = false}},
                { new Video{ Id = 3, Title = "ThirdVideo", IsProcessed = false }}
            };
            _mockRepository.Setup(r => r.GetUnprocessedVideos()).Returns(videos);
            var videoIds = _videoService.GetUnprocessedVideosAsCsv();
            Assert.That(videoIds, Does.Contain("1,2,3").IgnoreCase);
        }
    }
}
