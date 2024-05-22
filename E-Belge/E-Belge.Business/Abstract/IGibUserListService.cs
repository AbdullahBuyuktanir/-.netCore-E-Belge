using Core.Utilities.ResultModel.Concrete;
using E_Belge.Model.DataTransferObjects;

namespace E_Belge.Business.Abstract;

public interface IGibUserListService
{
  GibUserListDto? GetGibUserList(string vergiNo);
  Task<PaginationDataResult<IEnumerable<GibUserListDto>>> GetGibUserListAllAsync(PaginationQuery pagination, object? param = null);
  Task<int> InsertGibUserList(GibUserListDto model);
  Task<int> UpdateGibUserList(GibUserListDto model);
}
