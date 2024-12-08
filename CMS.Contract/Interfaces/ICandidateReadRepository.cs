using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Contract.Interfaces
{
    public interface ICandidateReadRepository
    {
        Task<Candidate> GetByEmailAsync(string email, CancellationToken cancellationToken);
    }
}
