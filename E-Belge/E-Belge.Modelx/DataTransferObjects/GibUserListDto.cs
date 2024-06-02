using Core.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Belge.Model.DataTransferObjects
{
  public class GibUserListDto : IDto
  {
    public int GibUserId { get; set; }
    public required string VergiNo { get; set; }
    public string? Unvan { get; set; }
    public required string Etiket { get; set; }
    public required string BelgeTipi { get; set; }
    public required string AdresTipi { get; set; }
    public required DateTime OlusturmaTarihi { get; set; }
    public required DateTime IlkOlusturmaTarihi { get; set; }
    public DateTime SilinmeTarihi { get; set; }
  }
}
