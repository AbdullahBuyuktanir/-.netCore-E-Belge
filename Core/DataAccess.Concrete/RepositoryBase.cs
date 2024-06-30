using Core.DataAccess.Abstract;
using Core.Model.Abstract;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Z.Dapper.Plus;
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

  public void BulkInsert<TModel>(List<TModel> modelList, string tableName) where TModel : class
  {
    try
    {
      DapperPlusManager.Entity<TModel>().Table(tableName).Key("ETIKET_NO");

      using (NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("PostgreSQLConnection")))
      {
        var XY = connection.BulkDelete(connection.Query<TModel>(@"Select * FROM ""EDGIMUKE"" where ""ETIKET_NO"" > 50").ToList());
      }


      DapperPlusManager.Entity<TModel>().Table(tableName);

      using (NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("PostgreSQLConnection")))
      {
        var xx = connection.BulkInsert(modelList);
      }
    }
    catch (Exception ex)
    {
    }
  }



  //public void BulkInsert<TModel>(List<TModel> modelList, TModel model) where TModel: class 
  //{
  //  DapperPlusManager.Entity<TModel>().Table(typeof(TModel).Name);
  //  using (NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("PostgreSQLConnection")))
  //  {
  //    var xx = connection.BulkInsert(modelList);
  //  }
  //}
}
