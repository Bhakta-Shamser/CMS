using CMS.Application.Candidate.Commands;
using CMS.Contract.Interfaces;
using CMS.Domain.Entities;
using FluentAssertions;
using Moq;

namespace CMS.UnitTest.IntegrationTests.Handler
{
    public class AddOrUpdateCandidateCommandHandlerTests
    {
        private readonly Mock<ICandidateRepository> _mockRepository;
        private readonly Mock<ICandidateReadRepository> _mockQueryRepository;
        private readonly AddCandidateCommandHandler _handler;

        public AddOrUpdateCandidateCommandHandlerTests()
        {
            _mockRepository = new Mock<ICandidateRepository>();
            _mockQueryRepository = new Mock<ICandidateReadRepository>();
            _handler = new AddCandidateCommandHandler(_mockRepository.Object, _mockQueryRepository.Object);

        }

        [Fact]
        public async Task Handle_ShouldAddNewCandidate_WhenCandidateDoesNotExist()
        {
            // Arrange
            var command = new AddCandidateCommand(
                "test@example.com",
                "John",
                "Doe",
                "1234567890",
                null,
                null,
                null,
                null,
                "New Candidate");

            _mockQueryRepository
                .Setup(repo => repo.GetByEmailAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Candidate)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().Be("test@example.com");
            _mockRepository.Verify(repo => repo.AddAsync(It.IsAny<Candidate>(), It.IsAny<CancellationToken>()), Times.Once);
            _mockRepository.Verify(repo => repo.UpdateAsync(It.IsAny<Candidate>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task Handle_ShouldUpdateExistingCandidate_WhenCandidateExists()
        {
            // Arrange
            var existingCandidate = new Candidate(
                "test@example.com",
                "OldFirstName",
                "OldLastName",
                "9876543210",
                null,
                null,
                null,
                null,
                "Old Comment");

            var command = new AddCandidateCommand(
                "test@example.com",
                "John",
                "Doe",
                "1234567890",
                null,
                null,
                null,
                null,
                "Updated Comment");

            _mockQueryRepository
                .Setup(repo => repo.GetByEmailAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingCandidate);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().Be("Updated successfully.");
            _mockRepository.Verify(repo => repo.UpdateAsync(It.IsAny<Candidate>(), It.IsAny<CancellationToken>()), Times.Once);
            _mockRepository.Verify(repo => repo.AddAsync(It.IsAny<Candidate>(), It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
