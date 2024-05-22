using Core.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Abstract
{
  public interface IGenericRepository
  {
    TModel? Get<TModel>(string query, object? param = null);
    Task<IEnumerable<TModel>> GetAllAsync<TModel>(string query, object? param = null);
    int Execute<TModel>(string query, TModel model);
    int ExecuteScalar(string query);

    //bulk insert
    //procedure select gibi sql operasyonlarını da ekle zamanla 
  }
}
