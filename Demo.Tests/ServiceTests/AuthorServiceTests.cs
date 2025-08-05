
using Xunit; 
using Moq; 
using Application.Services;
using Application.Interfaces; 
using Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggerAppV2.Tests.AuthorServiceTests // Adjust namespace
{
    public class AuthorServiceTests
    {
        [Fact] // XUnit attribute: Marks this method as a test to be run
        public async Task GetAll_ReturnsAllAuthors()
        {
            // Arrange
            // This is where you set up your test environment.

            // 1. Create the mock data that the repository would "return"
            var mockAuthors = new List<Author>
            {
                new Author { Id = 1, PenName = "Author A" },
                new Author { Id = 2, PenName = "Author B" }
            };

            // 2. Create a mock object for the IAuthorRepo dependency
            var mockRepo = new Mock<IAuthorRepository>();

            // 3. Set up the mock's behavior: when GetAllAsync() is called,
            //    it should return our mock data.
            mockRepo.Setup(repo => repo.GetAllAsync())
                    .ReturnsAsync(mockAuthors);

            // 4. Instantiate the System Under Test (SUT) - your AuthorService.
            //    Inject the mock repository's object, not the mock itself.
            var service = new AuthorService(mockRepo.Object);

            // Act
            // This is where you call the method being tested.
            var result = await service.GetAllAsync();

            // Assert
            // This is where you verify the result and behavior.

            // 1. Assert that the service method returned the expected number of items.
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());

            // 2. Assert that the service method correctly called its dependency's method.
            //    (Verify that GetAllAsync() on the mock was called exactly once.)
            mockRepo.Verify(repo => repo.GetAllAsync(), Times.Once);
        }
    }
}