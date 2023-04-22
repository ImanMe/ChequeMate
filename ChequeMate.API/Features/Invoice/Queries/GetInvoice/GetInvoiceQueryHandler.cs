using AutoMapper;
using ChequeMate.API.DTOs;
using ChequeMate.Persistence.Contracts;
using MediatR;

namespace ChequeMate.API.Features.Invoice.Queries.GetInvoice;

public class GetInvoiceQueryHandler : IRequestHandler<GetInvoiceQuery, InvoiceVm>
{
    private readonly IMapper _mapper;
    private readonly IInvoiceUnitOfWork _unitOfWork;

    public GetInvoiceQueryHandler(IMapper mapper, IInvoiceUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<InvoiceVm> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
    {
        var invoice = await _unitOfWork.InvoiceRepository.GetByIdWithListItems(request.Id);

        var invoiceVm = _mapper.Map<InvoiceVm>(invoice);

        return invoiceVm;
    }
}