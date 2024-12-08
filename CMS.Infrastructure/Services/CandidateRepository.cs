using CMS.Contract.Interfaces;
using CMS.Domain.Entities;
using CMS.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Services
{
    public class CandidateRepository : BaseRepository, ICandidateRepository, ICandidateReadRepository
    {
        private readonly ApplicationDbContext _dbContext;


        public CandidateRepository(ISqlConnectionFactory connectionFactory, ApplicationDbContext dbContext)
             : base(connectionFactory)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Candidate candidate, CancellationToken cancellationToken)
        {
            await _dbContext.Candidates.AddAsync(candidate, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task<Candidate?> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            var query = "SELECT * FROM Candidates WHERE Email = @Email";
            var parameters = new { Email = email };
            return await ExecuteQuerySingleAsync<Candidate>(query, parameters, cancellationToken);
        }

        public async Task UpdateAsync(Candidate candidate, CancellationToken cancellationToken)
        {
            _dbContext.Candidates.Update(candidate);
           
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

    }
}
