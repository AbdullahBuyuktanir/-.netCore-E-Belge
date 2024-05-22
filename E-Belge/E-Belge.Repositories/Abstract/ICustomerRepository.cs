using E_Belge.Model.DataTransferObjects;
using E_Belge.Model.Model;

namespace E_Belge.Repositories.Abstract;

public interface ICustomerRepository
{
  Cari? GetCustomer(string query, object? param = null);
  Task<IEnumerable<Cari>> GetCustomerAllAsync(string query, object? param = null);
  int ExecuteCustomer(string query, CreateUpdateCariDto model);
  int DeleteCustomer(string query, object param);
  int GetCountCustomer(string query);
}
