using Core.DataAccess.Abstract;
using E_Belge.Model.DataTransferObjects;
using E_Belge.Model.Model;
using E_Belge.Repositories.Abstract;

namespace E_Belge.Repositories.Concrete;

public class CustomerRepository : ICustomerRepository
{
  private readonly IGenericRepository _dbRepository;

  public CustomerRepository(IGenericRepository dbRepository)
  {
    _dbRepository = dbRepository;
  }

  public int DeleteCustomer(string query, object param)
  {
    return _dbRepository.Execute<object>(query, param);
  }

  public int ExecuteCustomer(string query, CreateUpdateCariDto model)
  {
    return _dbRepository.Execute<CreateUpdateCariDto>(query, model);
  }

  public async Task<IEnumerable<Cari>> GetCustomerAllAsync(string query, object? param = null)
  {
    return await _dbRepository.GetAllAsync<Cari>(query, param);
  }

  public Cari? GetCustomer(string query, object? param = null)
  {
    return _dbRepository.Get<Cari>(query, param);
  }

  public int GetCountCustomer(string query)
  {
    return _dbRepository.ExecuteScalar(query);
  }
}
