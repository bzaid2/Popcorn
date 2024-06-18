using Microsoft.VisualStudio.TestTools.UnitTesting;
using Popcorn.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Popcorn.Tests
{
    [TestClass]
    public class MovieServiceTest
    {
        private IJson jsonService;
        private ILoggerManager loggerService;
        private IMovie movieService;

        public MovieServiceTest()
        {
            loggerService = new Plugins.LoggerManager();
            jsonService = new Plugins.JsonService(loggerService);
            movieService = new Services.MovieService(jsonService, loggerService);
        }

        [TestMethod]
        public async Task GetAllMovies()
        {
            // Arrange

            // Act
            var result = await movieService.GetListOfMoviesByPageAsync(1);

            // Assert
            Assert.IsTrue(result != null && result.record.response.groups.Count() > 0);
        }
    }
}