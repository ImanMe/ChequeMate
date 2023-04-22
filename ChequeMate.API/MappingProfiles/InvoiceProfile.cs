using AutoMapper;
using ChequeMate.API.DTOs;
using ChequeMate.API.Features.Invoice.Commands.CreateInvoice;
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
                o.MapFrom(src => src.DueDate))
            .ForMember(dest => dest.PaymentDate, o => 
                o.MapFrom(src => src.PaymentDate))
            .ForMember(dest => dest.ListItemDtos, o =>
                o.MapFrom(src => src.ListItems));

        CreateMap<ListItemCreateDto, ListItem>();
        CreateMap<CreateInvoiceCommand, Invoice>()
            .ForMember(dest => dest.DueDate, o => 
                o.MapFrom(src => DateTime.Parse(src.DueDate)));

    }
}