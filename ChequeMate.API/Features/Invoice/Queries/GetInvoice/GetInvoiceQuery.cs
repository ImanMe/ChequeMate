using ChequeMate.API.DTOs;
using MediatR;

namespace ChequeMate.API.Features.Invoice.Queries.GetInvoice;

public class GetInvoiceQuery : IRequest<InvoiceVm>
{
    public GetInvoiceQuery(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}