using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using BasicCRUDTool3.Business;
using BasicCRUDTool3.Windows.DTO;

namespace BasicCRUDTool3.Blazor.Shared.MappingProfiles
{
    public class BusinessEntityDTOMapping : Profile
    {
        public BusinessEntityDTOMapping()
        {
            CreateMap<AlbumBE, AlbumBEDTO>();
            CreateMap<AlbumBEDTO, AlbumBE>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<ArtistBE, ArtistBEDTO>();
            CreateMap<ArtistBEDTO, ArtistBE>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<CustomerBE, CustomerBEDTO>();
            CreateMap<CustomerBEDTO, CustomerBE>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<GenreBE, GenreBEDTO>();
            CreateMap<GenreBEDTO, GenreBE>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<InvoiceBE, InvoiceBEDTO>();
            CreateMap<InvoiceBEDTO, InvoiceBE>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<InvoiceLineBE, InvoiceLineBEDTO>();
            CreateMap<InvoiceLineBEDTO, InvoiceLineBE>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<MediaTypeBE, MediaTypeBEDTO>();
            CreateMap<MediaTypeBEDTO, MediaTypeBE>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<PlaylistBE, PlaylistBEDTO>();
            CreateMap<PlaylistBEDTO, PlaylistBE>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<PlaylistTrackBE, PlaylistTrackBEDTO>();
            CreateMap<PlaylistTrackBEDTO, PlaylistTrackBE>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<TrackBE, TrackBEDTO>();
            CreateMap<TrackBEDTO, TrackBE>().IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
