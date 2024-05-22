using Core.DataAccess.Abstract;
using Core.DataAccess.Concrete;
using E_Belge.Model.Model;
using E_Belge.Repositories.Abstract;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Belge.Repositories.Concrete;

public class GibUserListRepository : IGibUserListRepository
{
  private readonly IGenericRepository _dbRepository;

  public GibUserListRepository(IGenericRepository dbRepository)
  {
    _dbRepository = dbRepository;
  }

  public async Task<IEnumerable<GibUserList>> GetGibUserListAllAsync(string query, object? param = null)
  {
    return await _dbRepository.GetAllAsync<GibUserList>(query, param);
  }

  public GibUserList? GetGibUserList(string query, object? param = null)
  {
    return _dbRepository.Get<GibUserList>(query, param);
  }

  public int ExecuteGibUserList(string query, GibUserList model)
  {
    return _dbRepository.Execute<GibUserList>(query, model);
  }

  public int GetCountGibUserList(string query)
  {
    return _dbRepository.ExecuteScalar(query);
  }
}
