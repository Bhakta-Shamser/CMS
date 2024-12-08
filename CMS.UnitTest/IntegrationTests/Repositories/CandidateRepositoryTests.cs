using CMS.Contract.Interfaces;
using CMS.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.UnitTest.IntegrationTests.Repositories
{
    public class CandidateRepositoryTests
    {
        private readonly Mock<ICandidateReadRepository> _mockConnectionFactory;
        public CandidateRepositoryTests()
        {
            _mockConnectionFactory = new Mock<ICandidateReadRepository>();
        }

        [Fact]
        public async Task GetByEmailSqlAsync_ShouldReturnCandidate_WhenEmailExists()
        {
            // Arrange
            var email = "test@example.com";
            var expectedCandidate = new Candidate(
                email,
                "John",
                "Doe",
                null,  
                null, 
                null,
                null,
                null,
                null,
                ""
            );

            _mockConnectionFactory
                .Setup(repo => repo.GetByEmailAsync(email, CancellationToken.None))
                .ReturnsAsync(expectedCandidate);

            
            var candidateRepository = _mockConnectionFactory.Object;

            // Act
            var result = await candidateRepository.GetByEmailAsync(email, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCandidate.Email, result.Email);
            Assert.Equal(expectedCandidate.FirstName, result.FirstName);
            Assert.Equal(expectedCandidate.LastName, result.LastName);
        }

    }
}
