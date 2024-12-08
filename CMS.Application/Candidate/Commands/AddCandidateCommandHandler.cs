using CMS.Contract.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Candidate.Commands
{
    public class AddCandidateCommandHandler : IRequestHandler<AddCandidateCommand, string>
    {
        private readonly ICandidateRepository _repository;
        private readonly ICandidateReadRepository _readRepository;
        public AddCandidateCommandHandler(ICandidateRepository repository, ICandidateReadRepository readRepository)
        {
            _repository = repository;
            _readRepository = readRepository;
        }

        public async Task<string> Handle(AddCandidateCommand request, CancellationToken cancellationToken)
        {
            var existingCandidate = await _readRepository.GetByEmailAsync(request.Email, cancellationToken);
            
            if (existingCandidate != null)
            {
               existingCandidate.UpdateDetails(
                request.FirstName,
                request.LastName,
                request.PhoneNumber,
                request.AvailableFrom,
                request.AvailableTo,
                request.LinkedInProfileUrl,
                request.GithubProfileUrl,
                request.Comment
            );

                await _repository.UpdateAsync(existingCandidate, cancellationToken);

                return "Updated successfully.";
            }
            else
            {
                var candidate = new CMS.Domain.Entities.Candidate(
                                request.Email,
                                request.FirstName,
                                request.LastName,
                                request.PhoneNumber,
                                null,
                                request.AvailableFrom,
                                request.AvailableTo,
                                request.LinkedInProfileUrl,
                                request.GithubProfileUrl,
                                request.Comment
                             );

                await _repository.AddAsync(candidate, cancellationToken);
                return candidate.Email;
            }
            
        }
    }
}
