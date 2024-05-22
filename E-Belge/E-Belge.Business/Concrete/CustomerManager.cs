using AutoMapper;
using Core.Utilities.ResultModel.Concrete;
using Core.Utilities.ResultModel.Results;
using Core.Utilities.Results;
using E_Belge.Business.Abstract;
using E_Belge.Business.Constants;
using E_Belge.Model.DataTransferObjects;
using E_Belge.Model.Model;
using E_Belge.Model.Validators;
using E_Belge.Model.Validators.Customers;
using E_Belge.Repositories.Abstract;
using FluentValidation;

namespace E_Belge.Business.Concrete;

public class CustomerManager : ICustomerService
{
  private readonly ICustomerRepository _repository;
  private readonly IMapper _mapper;

  public CustomerManager(ICustomerRepository repository, IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  public Result DeleteCustomerByCariNo(int cariNo)
  {
    if (_repository.DeleteCustomer(@"DELETE FROM ""CARILER"" WHERE ""CARI_NO"" = @cariNo", new { CariNo = cariNo }) > 0)
      return Result.Success(Messages.SuccessDeleting);

    return Result.Failure(Messages.FailedDeleting, BaseErrors.OperationFailed);
  }

  public Result DeleteCustomerByVkn(string vergiNo)
  {
    if (_repository.DeleteCustomer(@"DELETE FROM ""CARILER"" WHERE ""VKN_TCKN"" = @vergiNo", new { VergiNo = vergiNo }) > 0)
      return Result.Success(Messages.SuccessDeleting);

    return Result.Failure(Messages.FailedDeleting, BaseErrors.OperationFailed);
  }

  public async Task<PaginationDataResult<IEnumerable<CariDto>>> GetCustomerAllAsync(PaginationQuery pagination, object? param = null)
  {
    int count = _repository.GetCountCustomer("SELECT COUNT(*) FROM \"CARILER\"");
    int offset = (pagination.PageNumber - 1) * pagination.Limit;

    IEnumerable<Cari> cariList = await _repository.GetCustomerAllAsync(
      String.Format(@"SELECT ""CARI_NO"", ""CARI_ADI"", ""CARI_KODU"", ""VERGI_DAIRESI"",
                             ""VKN_TCKN"", ""SEHIR"", ""ILCE"", ""ULKE"", ""EMAIL""
	                      FROM ""CARILER""
                       LIMIT {0} OFFSET {1}", pagination.Limit, offset), param);

    IEnumerable<CariDto> listDest = _mapper.Map<IEnumerable<Cari>, IEnumerable<CariDto>>(cariList);

    return PaginationDataResult<IEnumerable<CariDto>>.Success(Messages.SuccessListing, listDest,
        pagination.PageNumber, pagination.Limit, count);
  }

  public DataResult<CariDto> GetCustomerByCariNo(int cariNo)
  {
    if (cariNo < 0)
      return DataResult<CariDto>.Failure(Messages.InvalidParameter, BaseErrors.ParameterIsInvalid("CariNo değeri 0'dan büyük olmalıdır."));

    Cari? cari = _repository.GetCustomer(
      @"SELECT ""CARI_NO"", ""CARI_ADI"", ""CARI_KODU"", ""VERGI_DAIRESI"", ""VKN_TCKN"", ""SOKAK"", ""MAHALLE"",
               ""BINA_NO"", ""BINA_ADI"", ""POSTA_KODU"", ""ADRES_ALANI"", ""SEHIR"", ""ILCE"", ""ULKE"", ""EMAIL""
	        FROM ""CARILER""
         WHERE ""CARI_NO"" = @CariNo", new { CariNo = cariNo });

    if (cari is null)
      return DataResult<CariDto>.Failure(Messages.NotFound, BaseErrors.NotFound(String.Concat("cariNo: ", cariNo)));

    return DataResult<CariDto>.Success(Messages.SuccessListing, _mapper.Map<CariDto>(cari));
  }

  public DataResult<CariDto> GetCustomerByVkn(string vergiNo)
  {
    if (String.IsNullOrEmpty(vergiNo))
      return DataResult<CariDto>.Failure(Messages.InvalidParameter, BaseErrors.CanNotNull(nameof(vergiNo)));

    Cari? cari = _repository.GetCustomer(
      @"SELECT ""CARI_NO"", ""CARI_ADI"", ""CARI_KODU"", ""VERGI_DAIRESI"", ""VKN_TCKN"", ""SOKAK"", ""MAHALLE"",
               ""BINA_NO"", ""BINA_ADI"", ""POSTA_KODU"", ""ADRES_ALANI"", ""SEHIR"", ""ILCE"", ""ULKE"", ""EMAIL""
	        FROM ""CARILER""
         WHERE ""VKN_TCKN"" = @VergiNo", new { VergiNo = vergiNo });

    if (cari is null)
      return DataResult<CariDto>.Failure(Messages.NotFound, BaseErrors.NotFound(String.Concat("vergiNo: ", vergiNo)));

    return DataResult<CariDto>.Success(Messages.SuccessListing, _mapper.Map<CariDto>(cari));
  }

  public Result InsertCustomer(CreateUpdateCariDto model)
  {
    Error error = ValidationClass.Validate(new CreateUpdateCustomerValidator(), model);

    if (error == Error.None)
    {
      if (_repository.ExecuteCustomer(
         @"INSERT INTO ""CARILER""(""CARI_ADI"", ""CARI_KODU"", ""VERGI_DAIRESI"", ""VKN_TCKN"", ""SOKAK"", ""MAHALLE"", 
                       ""BINA_NO"", ""BINA_ADI"", ""POSTA_KODU"", ""ADRES_ALANI"", ""SEHIR"", ""ILCE"", ""ULKE"", ""EMAIL"")
	           VALUES (@Adi, @Kodu, @VergiDairesi, @VknTckn, @Sokak, @Mahalle, @BinaNo, @BinaAdi,
                     @PostaKodu, @Adres, @Sehir, @Ilce, @Ulke, @Email);", model) > 0)
        return Result.Success(Messages.ModelAdded);

      return Result.Failure(Messages.ModelFailedInsert, BaseErrors.DataNotInsert);
    }
    else
      return Result.Failure(Messages.ModelIsInvalid, error);
  }

  public Result UpdateCustomer(CreateUpdateCariDto model)
  {
    return Result.Failure(Messages.ModelIsInvalid, BaseErrors.MaintenanceTime);

   // if (model == null)
   // { }
    // if model valid doğrulama 

    _repository.ExecuteCustomer(
      @"UPDATE ""CARILER""
	         SET ""CARI_ADI""=?, ""CARI_KODU""=?, ""VERGI_DAIRESI""=?, ""VKN_TCKN""=?, ""SOKAK""=?, ""MAHALLE""=?, ""BINA_NO""=?, ""BINA_ADI""=?, ""POSTA_KODU""=?, ""ADRES_ALANI""=?, ""SEHIR""=?, ""ILCE""=?, ""ULKE""=?, ""EMAIL""=?
	       WHERE ""CARI_NO""=?", model);

  }
}
