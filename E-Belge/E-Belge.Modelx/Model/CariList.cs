using Core.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Belge.Model.Model;

public class EBelge : IModel
{
  public int ISLEM_NO { get; set; }
  public string BELGE_PROFIL { get; set; }
  public string BELGE_NO { get; set; }
  public string UUID { get; set; }
  public string TIP_KODU { get; set; }
  public string? NOT_ALANI { get; set; }
  public DateTime TARIH { get; set; }
  public Cari SATICI { get; set; }
  public Cari ALICI { get; set; }
  public decimal VERGILER_DAHIL_TUTAR { get; set; }
  public List<Vergi> VERGİLER { get; set; }
  public decimal GENEL_TOPLAM { get; set; }
  public decimal MATRAH { get; set; }

}

public class Vergi : IModel
{
  public int VERGI_NO { get; set; }
  public string VERGI_KODU { get; set; }
  public string VERGI_ADI { get; set; }
  public int ORANI { get; set; }
  public decimal MATRAH { get; set; }
  public decimal TUTAR { get; set; }
  public decimal VERGI_DAHIL_TUTAR { get; set; }
}

public class Cari : IModel
{
  public int CARI_NO { get; set; }
  public string CARI_ADI { get; set; }
  public string? CARI_KODU { get; set; }
  public string VERGI_DAIRESI { get; set; }
  public string VKN_TCKN { get; set; }
  public string? SOKAK { get; set; }
  public string? MAHALLE { get; set; }
  public string? BINA_NO { get; set; }
  public string? BINA_ADI { get; set; }
  public string? POSTA_KODU { get; set; }
  public string ADRES_ALANI { get; set; }
  public string SEHIR { get; set; }
  public string ILCE { get; set; }
  public string ULKE { get; set; }
  public string? EMAIL { get; set; }
}

public class StokList : IModel
{
  public int STOK_NO { get; set; }
  public string STOK_ADI { get; set; }
  public string? STOK_KODU { get; set; }
  public decimal BIRIM_FIYAT { get; set; }
  public decimal VERGILER_DAHIL_TUTAR { get; set; }
  public decimal MIKTAR { get; set; }
  public string BIRIM { get; set; }
  public string VERGI_ADI { get; set; }
  public string VERGI_KODU { get; set; }
  public decimal VERGI_TUTARI { get; set; }
}


