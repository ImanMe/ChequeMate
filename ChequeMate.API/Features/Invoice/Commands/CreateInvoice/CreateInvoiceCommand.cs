using MediatR;

namespace ChequeMate.API.Features.Invoice.Commands.CreateInvoice;

public class CreateInvoiceCommand : IRequest<CreateInvoiceResponse>
{
    public string CustomerName { get; set; }
    public string DueDate { get; set; }
    public List<ListItemCreateDto> ListItems { get; set; }
}
public class ListItemCreateDto
{
    public string Description { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}