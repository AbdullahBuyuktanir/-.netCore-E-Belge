using Core.Utilities.ResultModel.Concrete;
using Core.Utilities.Results;
using E_Belge.Model.DataTransferObjects;
using E_Belge.Model.Model;

namespace E_Belge.Business.Abstract;

public interface ICustomerService
{
  DataResult<CariDto> GetCustomerByCariNo(int cariNo);
  DataResult<CariDto> GetCustomerByVkn(string vergiNo);
  Task<PaginationDataResult<IEnumerable<CariDto>>> GetCustomerAllAsync(PaginationQuery pagination, object? param = null);
  Result InsertCustomer(CreateUpdateCariDto model);
  Result UpdateCustomer(CreateUpdateCariDto model);
  Result DeleteCustomerByCariNo(int cariNo);
  Result DeleteCustomerByVkn(string vergiNo);
}
