using MediatR;

namespace CMS.Application.Candidate.Commands
{
    public sealed record AddCandidateCommand(
     string Email,
     string FirstName,
     string LastName,
     string? PhoneNumber,
     DateTime? AvailableFrom,
     DateTime? AvailableTo,
     string? LinkedInProfileUrl,
     string? GithubProfileUrl,
     string Comment
     ) : IRequest<string>;
}
