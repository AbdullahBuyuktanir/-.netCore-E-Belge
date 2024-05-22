using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Belge.Business.Constants;
public static class Messages
{
  public static string ModelAdded = "Model eklendi.";
  public static string ModelIsInvalid = "Model, doğrulanamadı; geçersiz veriler içeriyor.";
  public static string ModelFailedInsert = "Model, veritabanına kaydedilemedi.";
  public static string SuccessListing = "Listeleme başarılı.";
  public static string SuccessDeleting = "Silme işlemi başarılı.";
  public static string FailedDeleting = "Silme işlemi başarısız.";
  public static string InvalidParameter = "Geçersiz parametre.";
  public static string NotFound = "Model bulunamadı.";
  public static string InternalServerError = "Internal server error.";
}
