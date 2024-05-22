using Core.Utilities.ResultModel.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Belge.Business.Constants;

public static class BaseErrors
{
  public static Error NotFound(string param) =>
    new("Not_Found", $"Veritabanında belirtilen '{param}' bulunmuyor.");

  public static Error CanNotNull(String paramName) =>
    new("Param_Not_Null", $"'{paramName}' null olamaz.");

  public static Error ParameterIsInvalid(string paramsFeature) =>
    new("Params_Is_Invalid", $"'{paramsFeature}'.");

  public static readonly Error ModelIsInvalid =
    new("Model_Is_Invalid", "Model, doğrulanamadı; geçersiz veriler içeriyor.");

  public static readonly Error DataNotInsert =
    new("Data_Not_Insert", "Veri kaydedilemedi.");

  public static readonly Error OperationFailed =
    new("Operation_Failed", "İşlem başarısız; girilen parametreler var olan bir veriye karşılık gelmiyor olabilir.");

  public static readonly Error DbErrors =
    new("Db_Errors", "Veritabanı işlemi gerçekleştirilemedi.");

  public static readonly Error AuthorizationDenied =
    new("Authorization_Denied", "Yetkisiz işlem.");

  public static readonly Error MaintenanceTime =
    new("Maintenance_Time", "Sistem bakımda.");
}
