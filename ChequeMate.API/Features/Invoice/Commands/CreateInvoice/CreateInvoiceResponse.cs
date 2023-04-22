using ChequeMate.API.DTOs;

namespace ChequeMate.API.Features.Invoice.Commands.CreateInvoice;

public class CreateInvoiceResponse : BaseResponse
{
    public CreateInvoiceResponse(bool success, string message) : base(success, message)
    {
    }

    public InvoiceVm Invoice { get; set; }
}