using AutoMapper;
using ChequeMate.API.DTOs;
using ChequeMate.Persistence.Contracts;
using MediatR;

namespace ChequeMate.API.Features.Invoice.Commands.CreateInvoice;

public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, CreateInvoiceResponse>
{
    private readonly IMapper _mapper;
    private readonly IInvoiceUnitOfWork _invoiceUnitOfWork;

    public CreateInvoiceCommandHandler(IMapper mapper, IInvoiceUnitOfWork invoiceUnitOfWork)
    {
        _mapper = mapper;
        _invoiceUnitOfWork = invoiceUnitOfWork;
    }
    public async Task<CreateInvoiceResponse> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateInvoiceCommandValidator();

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            var errorResponse = new CreateInvoiceResponse(false, "Failed to create invoice.");

            foreach (var error in validationResult.Errors)
                errorResponse.ValidationErrors.Add(error.ErrorMessage);
            
            return errorResponse;
        }

        var invoice = _mapper.Map<Domain.Entities.Invoice>(request);

        _invoiceUnitOfWork.InvoiceRepository.Add(invoice);

        await _invoiceUnitOfWork.SaveChangesAsync();

        var response = new CreateInvoiceResponse(true, "Invoice was created")
        {
            Invoice = _mapper.Map<InvoiceVm>(invoice)
        };

        return response;
    }
}