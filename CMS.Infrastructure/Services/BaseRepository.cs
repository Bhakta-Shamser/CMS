using System.Data;
using CMS.Contract.Interfaces;
using Dapper;

namespace CMS.Infrastructure.Services
{
    public abstract class BaseRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        protected BaseRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        protected async Task<IEnumerable<T>> ExecuteQueryAsync<T>(string query, object parameters = null, CancellationToken cancellationToken = default)
        {
            using (var connection = await _connectionFactory.CreateConnectionAsync(cancellationToken))
            {
                return await connection.QueryAsync<T>(query, parameters, commandType: CommandType.Text, commandTimeout: 30);
            }
        }

        protected async Task<T> ExecuteQuerySingleAsync<T>(string query, object parameters = null, CancellationToken cancellationToken = default)
        {
            using (var connection = await _connectionFactory.CreateConnectionAsync(cancellationToken))
            {
                return await connection.QuerySingleOrDefaultAsync<T>(query, parameters, commandType: CommandType.Text, commandTimeout: 30);
            }
        }
    }
}
