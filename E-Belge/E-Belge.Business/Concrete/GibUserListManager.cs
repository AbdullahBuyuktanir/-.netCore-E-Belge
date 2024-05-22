using AutoMapper;
using Core.Utilities.ResultModel.Concrete;
using E_Belge.Business.Abstract;
using E_Belge.Business.Constants;
using E_Belge.Model.DataTransferObjects;
using E_Belge.Model.Model;
using E_Belge.Repositories.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Belge.Business.Concrete
{
  public class GibUserListManager : IGibUserListService
  {
    private readonly IGibUserListRepository _repository;
    private readonly IMapper _mapper;

    public GibUserListManager(IGibUserListRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<PaginationDataResult<IEnumerable<GibUserListDto>>> GetGibUserListAllAsync(PaginationQuery pagination, object? param = null)
    {
      int count = _repository.GetCountGibUserList("SELECT COUNT(*) FROM \"EDGIMUKE\"");
      int offset = (pagination.PageNumber - 1) * pagination.Limit;

      IEnumerable<GibUserList> gibUserList = await _repository.GetGibUserListAllAsync(
        String.Format(@"SELECT ""ETIKET_NO"", ""MUKELLEF_VERGI_NO"", ""MUKELLEF_UNVANI"", ""MUKELLEF_ETIKETI"", ""ADRES_TURU"", ""BELGE_TURU"", 
                               ""OLUSTURMA_TARIHI"", ""ILK_OLUSTURMA_TARIHI"", ""SILINME_TARIHI"" 
                          FROM ""EDGIMUKE""
                         LIMIT {0} OFFSET {1}", pagination.Limit, offset), param);

      IEnumerable<GibUserListDto> listDest = _mapper.Map<IEnumerable<GibUserList>, IEnumerable<GibUserListDto>>(gibUserList);

      return PaginationDataResult<IEnumerable<GibUserListDto>>.Success(Messages.SuccessListing, listDest,
        pagination.PageNumber, pagination.Limit, count);
    }

    public GibUserListDto? GetGibUserList(string vergiNo)
    {
      if (String.IsNullOrEmpty(vergiNo))
      {
        //hata fırlat
      }

      GibUserList? gibUserList = _repository.GetGibUserList(
        @"SELECT ""ETIKET_NO"", ""MUKELLEF_VERGI_NO"", ""MUKELLEF_UNVANI"", ""MUKELLEF_ETIKETI"", ""ADRES_TURU"", ""BELGE_TURU"", 
                 ""OLUSTURMA_TARIHI"", ""ILK_OLUSTURMA_TARIHI"", ""SILINME_TARIHI"" 
            FROM ""EDGIMUKE"" 
           WHERE ""MUKELLEF_VERGI_NO"" = @vergiNo", new { vergiNo = vergiNo });

      return _mapper.Map<GibUserListDto>(gibUserList);
    }

    public Task<int> InsertGibUserList(GibUserListDto model)
    {
      throw new NotImplementedException();
    }

    public Task<int> UpdateGibUserList(GibUserListDto model)
    {
      throw new NotImplementedException();
    }
  }
}
