using CMS.Contract.Dtos;
using MediatR;

namespace CMS.Application.Candidate.Queries
{
    public record GetCandidateByEmailQuery(string Email) : IRequest<CandidateDto>;
}
