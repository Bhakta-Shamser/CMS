using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Contract.Interfaces
{
    public interface ICandidateRepository
    {
        Task AddAsync(Candidate candidate, CancellationToken cancellationToken);
        Task UpdateAsync(Candidate candidate, CancellationToken cancellationToken);
    }
}
