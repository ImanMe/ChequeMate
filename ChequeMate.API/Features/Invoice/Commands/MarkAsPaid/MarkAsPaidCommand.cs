using MediatR;

namespace ChequeMate.API.Features.Invoice.Commands.MarkAsPaid;

public class MarkAsPaidCommand : IRequest<MarkAsPaidResponse>
{
    public MarkAsPaidCommand(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}