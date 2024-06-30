using Core.Utilities.ResultModel.Concrete;
using E_Belge.Model.DataTransferObjects;
using E_Belge.Model.Model;

namespace E_Belge.Business.Abstract;

public interface IGibUserListService
{
  GibUserListDto? GetGibUserList(string vergiNo);
  Task<PaginationDataResult<IEnumerable<GibUserListDto>>> GetGibUserListAllAsync(PaginationQuery pagination, object? param = null);
  void BulkInsertGibUserList();
  Task<int> UpdateGibUserList(GibUserListDto model);
}
