using Core.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Belge.Model.DataTransferObjects;

public class CreateUpdateCariDto
{
  public string Adi { get; set; }
  public string? Kodu { get; set; }
  public string VergiDairesi { get; set; }
  public string VknTckn { get; set; }
  public string? Sokak { get; set; }
  public string? Mahalle { get; set; }
  public string? BinaNo { get; set; }
  public string? BinaAdi { get; set; }
  public string? PostaKodu { get; set; }
  public string Adres { get; set; }
  public string Sehir { get; set; }
  public string Ilce { get; set; }
  public string Ulke { get; set; }
  public string? Email { get; set; }
}
