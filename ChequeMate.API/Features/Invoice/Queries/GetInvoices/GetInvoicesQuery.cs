using ChequeMate.API.DTOs;
using MediatR;

namespace ChequeMate.API.Features.Invoice.Queries.GetInvoices;

public class GetInvoicesQuery : IRequest<InvoiceQueryResultVm>
{
    public GetInvoicesQuery(bool? isPaid)
    {
        IsPaid = isPaid;
    }
    public bool? IsPaid { get; set; }
}