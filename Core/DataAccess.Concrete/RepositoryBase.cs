using Core.DataAccess.Abstract;
using Core.Model.Abstract;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
namespace Core.DataAccess.Concrete;

public class RepositoryBase : IGenericRepository
{
  private readonly IConfiguration _config;

  public RepositoryBase(IConfiguration config)
  {
    _config = config;
  }

  public int ExecuteScalar(string query)
  {
    using (NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("PostgreSQLConnection")))
    {
      return connection.ExecuteScalar<int>(query);
    }
  }

  public int Execute<TModel>(string query, TModel model)
  {
    using (NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("PostgreSQLConnection")))
    {
      return connection.Execute(query, model);
    }
  }

  public async Task<IEnumerable<TModel>> GetAllAsync<TModel>(string query, object? param = null)
  {
    using (NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("PostgreSQLConnection")))
    {
      var result = await connection.QueryAsync<TModel>(query, param);
      return result.ToList();
    }
  }

  public TModel? Get<TModel>(string query, object? param = null)
  {
    using (NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("PostgreSQLConnection")))
    {
      return connection.QueryFirstOrDefault<TModel>(query, param);
    }
  }
}
