using ChequeMate.Persistence.Contracts;
using MediatR;

namespace ChequeMate.API.Features.Invoice.Commands.MarkAsPaid;

public class MarkAsPaidCommandHandler : IRequestHandler<MarkAsPaidCommand, MarkAsPaidResponse>
{
    private readonly IInvoiceUnitOfWork _unitOfWork;

    public MarkAsPaidCommandHandler(IInvoiceUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<MarkAsPaidResponse> Handle(MarkAsPaidCommand request, CancellationToken cancellationToken)
    {
        var invoice = await _unitOfWork.InvoiceRepository.GetById(request.Id);

        if (invoice == null)
            return new MarkAsPaidResponse(false, $"No invoice with Id:{request.Id} exists.");
        
        if (invoice.IsPaid)
            return new MarkAsPaidResponse(true, $"Invoice with Id: {request.Id} is already set as paid.");
        
        invoice.SetAsPaid();

        _unitOfWork.InvoiceRepository.Update(invoice);

        await _unitOfWork.SaveChangesAsync();

        var response = new MarkAsPaidResponse(true, $"Invoice with Id: {request.Id} is set as paid.");

        return response;
    }
}