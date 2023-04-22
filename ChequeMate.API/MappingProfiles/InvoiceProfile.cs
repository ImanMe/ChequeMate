using AutoMapper;
using ChequeMate.API.DTOs;
using ChequeMate.Domain.Entities;

namespace ChequeMate.API.MappingProfiles;

public class InvoiceProfile : Profile
{
    public InvoiceProfile()
    {
        CreateMap<ListItem, ListItemVm>();
        CreateMap<Invoice, InvoiceVm>()
            .ForMember(dest => dest.InvoiceDate, o =>
                o.MapFrom(src => src.CreatedDate))
            .ForMember(dest => dest.DueDate, o => 
                o.MapFrom(src => src.DueDate.ToShortDateString()))
            .ForMember(dest => dest.PaymentDate, o => 
                o.MapFrom(src => src.PaymentDate.HasValue ? src.PaymentDate.Value.ToShortDateString() : ""));
    }
}