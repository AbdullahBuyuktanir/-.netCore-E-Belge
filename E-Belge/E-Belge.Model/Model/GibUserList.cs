using Core.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Belge.Model.Model
{
  public class GibUserList : IModel
  {
    public int ETIKET_NO { get; set; }
    public required string MUKELLEF_VERGI_NO { get; set; }
    public string? MUKELLEF_UNVANI { get; set; }
    public required string MUKELLEF_ETIKETI { get; set; }
    public required string BELGE_TURU { get; set; }
    public required string ADRES_TURU { get; set; }
    public required DateTime OLUSTURMA_TARIHI { get; set; }
    public required DateTime ILK_OLUSTURMA_TARIHI { get; set; }
    public DateTime SILINME_TARIHI { get; set; }
  }
}
