using CMS.Contract.Dtos;
using CMS.Contract.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Candidate.Queries
{
    public class GetCandidateByEmailQueryHandler : IRequestHandler<GetCandidateByEmailQuery, CandidateDto>
    {
        private readonly ICandidateReadRepository _repository;

        public GetCandidateByEmailQueryHandler(ICandidateReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<CandidateDto> Handle(GetCandidateByEmailQuery request, CancellationToken cancellationToken)
        {
            var candidate = await _repository.GetByEmailAsync(request.Email, cancellationToken);
            return new CandidateDto(candidate.Email, candidate.FirstName, candidate.LastName);
        }
    }
}
