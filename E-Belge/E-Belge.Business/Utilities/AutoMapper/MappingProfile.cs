using AutoMapper;
using E_Belge.Model.DataTransferObjects;
using E_Belge.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Belge.Business.Utilities.AutoMapper;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<GibUserList, GibUserListDto>()
     .ForMember(dest => dest.Etiket, opt => opt.MapFrom(src => src.MUKELLEF_ETIKETI))
     .ForMember(dest => dest.AdresTipi, opt => opt.MapFrom(src => src.ADRES_TURU))
     .ForMember(dest => dest.OlusturmaTarihi, opt => opt.MapFrom(src => src.OLUSTURMA_TARIHI))
     .ForMember(dest => dest.SilinmeTarihi, opt => opt.MapFrom(src => src.SILINME_TARIHI))
     .ForMember(dest => dest.BelgeTipi, opt => opt.MapFrom(src => src.BELGE_TURU))
     .ForMember(dest => dest.IlkOlusturmaTarihi, opt => opt.MapFrom(src => src.ILK_OLUSTURMA_TARIHI))
     .ForMember(dest => dest.Unvan, opt => opt.MapFrom(src => src.MUKELLEF_UNVANI))
     .ForMember(dest => dest.VergiNo, opt => opt.MapFrom(src => src.MUKELLEF_VERGI_NO));

    CreateMap<Cari, CariDto>()
     .ForMember(dest => dest.Adi, opt => opt.MapFrom(src => src.CARI_ADI))
     .ForMember(dest => dest.CariNo, opt => opt.MapFrom(src => src.CARI_NO))
     .ForMember(dest => dest.Kodu, opt => opt.MapFrom(src => src.CARI_KODU))
     .ForMember(dest => dest.VergiDairesi, opt => opt.MapFrom(src => src.VERGI_DAIRESI))
     .ForMember(dest => dest.VknTckn, opt => opt.MapFrom(src => src.VKN_TCKN))
     .ForMember(dest => dest.Sehir, opt => opt.MapFrom(src => src.SEHIR))
     .ForMember(dest => dest.Ilce, opt => opt.MapFrom(src => src.ILCE))
     .ForMember(dest => dest.Ulke, opt => opt.MapFrom(src => src.ULKE));
  }
}
