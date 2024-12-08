using CMS.Contract.Dtos;
using CMS.Contract.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<GetCandidateByEmailQueryHandler> _logger;

        public GetCandidateByEmailQueryHandler(ILogger<GetCandidateByEmailQueryHandler> logger, ICandidateReadRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<CandidateDto> Handle(GetCandidateByEmailQuery request, CancellationToken cancellationToken)
        {
            var candidate = await _repository.GetByEmailAsync(request.Email, cancellationToken);
            if (candidate == null)
            {
                _logger.LogInformation($"Candidate with email '{request.Email}' was not found.");

                return null;
            }

            return new CandidateDto(candidate.Email, candidate.FirstName, candidate.LastName);
        }
    }
}
