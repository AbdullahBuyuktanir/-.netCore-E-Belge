using AutoMapper;
using Core.Utilities.ResultModel.Concrete;
using E_Belge.Business.Abstract;
using E_Belge.Business.Constants;
using E_Belge.Model.Classes;
using E_Belge.Model.DataTransferObjects;
using E_Belge.Model.Model;
using E_Belge.Repositories.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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

    public void BulkInsertGibUserList()
    {
      List<GibUserList> mukellefList = new List<GibUserList>();

      List<GibAccountAlias> gibAccAlias;
      List<GibAccount> gibAccount;
      try
      {
        using (MemoryStream memoryStream = new MemoryStream())
        {
          WebRequest.Create("https://gibuser.mysoft.com.tr/GibAccount.zip").GetResponse().GetResponseStream().CopyTo(memoryStream);
          using (StreamReader streamReader = new StreamReader(new ZipArchive(memoryStream, ZipArchiveMode.Read, false).Entries[0].Open(), Encoding.UTF8))
          {
            XmlSerializer serializer = new XmlSerializer(typeof(ArrayOfGibAccount));
            gibAccount = ((ArrayOfGibAccount)serializer.Deserialize(streamReader)).GibAccount.ToList();
            streamReader.Close();
          }
        }

        using (MemoryStream memoryStream = new MemoryStream())
        {
          WebRequest.Create("https://gibuser.mysoft.com.tr/GibAccountAlias.zip").GetResponse().GetResponseStream().CopyTo(memoryStream);
          using (StreamReader streamReader = new StreamReader(new ZipArchive(memoryStream, ZipArchiveMode.Read, false).Entries[0].Open(), Encoding.UTF8))
          {
            XmlSerializer serializer = new XmlSerializer(typeof(ArrayOfGibAccountAlias));
            gibAccAlias = ((ArrayOfGibAccountAlias)serializer.Deserialize(streamReader)).GibAccountAlias.Where(x => x.AliasType == 1).ToList();
            streamReader.Close();
          }
        }

        var gibAccountAndAlias = gibAccAlias.Join(gibAccount, x => x.GibAccountId, q => q.Id,
         (x, q) => new
         {
           x.Alias,
           x.AliasCreateDate,
           x.AliasDeleteDate,
           x.GibDocumentType,
           q.IdentifierNo,
           q.GibAccountName,
           q.EInvoiceStartDate,
           q.GibUserType,
           q.GibAccountUsageType
         }).ToList();

        Object etiketSilinme = DBNull.Value;
        for (int i = 0; i < gibAccountAndAlias.Count; i++)
        {
          if (String.IsNullOrEmpty(gibAccountAndAlias[i].AliasDeleteDate))
            etiketSilinme = DBNull.Value;
          else
            etiketSilinme = Convert.ToDateTime(gibAccountAndAlias[i].AliasDeleteDate);

          mukellefList.Add(new GibUserList()
          {
            MUKELLEF_VERGI_NO = gibAccountAndAlias[i].IdentifierNo,
            MUKELLEF_ETIKETI = gibAccountAndAlias[i].Alias,
            MUKELLEF_UNVANI = gibAccountAndAlias[i].GibAccountName,
            ILK_OLUSTURMA_TARIHI = Convert.ToDateTime(gibAccountAndAlias[i].EInvoiceStartDate),
            OLUSTURMA_TARIHI = gibAccountAndAlias[i].AliasCreateDate,
            BELGE_TURU = gibAccountAndAlias[i].GibDocumentType == 1 ? "Invoice" : "DespatchAdvice",
            ADRES_TURU = "PK",
            //     SILINME_TARIHI= etiketSilinme
          });
        }
      }
      catch (Exception ex)
      {
        throw new Exception(String.Format("ErrorMessage : {0}", ex.Message));
      }

      _repository.BulkInsertGibUserList(mukellefList);
    }

    public Task<int> UpdateGibUserList(GibUserListDto model)
    {
      throw new NotImplementedException();
    }
  }
}
