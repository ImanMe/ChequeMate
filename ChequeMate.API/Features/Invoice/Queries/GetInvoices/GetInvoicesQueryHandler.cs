using AutoMapper;
using ChequeMate.API.DTOs;
using ChequeMate.Persistence.Contracts;
using MediatR;

namespace ChequeMate.API.Features.Invoice.Queries.GetInvoices;

public class GetInvoicesQueryHandler : IRequestHandler<GetInvoicesQuery, InvoiceQueryResultVm>
{
    private readonly IMapper _mapper;
    private readonly IInvoiceUnitOfWork _invoiceUnitOfWork;

    public GetInvoicesQueryHandler(IMapper mapper, IInvoiceUnitOfWork invoiceUnitOfWork)
    {
        _mapper = mapper;
        _invoiceUnitOfWork = invoiceUnitOfWork;
    }
    public async Task<InvoiceQueryResultVm> Handle(GetInvoicesQuery request, CancellationToken cancellationToken)
    {
        var invoices = await _invoiceUnitOfWork.InvoiceRepository
            .GetAllWithListItemsByDueDate(request.IsPaid);

        var result = new InvoiceQueryResultVm
        {
            Invoices = _mapper.Map<IList<InvoiceVm>>(invoices),
            TotalAmountOfUnpaidInvoices = CalculateTotalAmountOfUnpaidInvoices(invoices),
            AverageTimeOfPayment = CalculateAverageTimeToPay(invoices)
        };

        return result;
    }

    private decimal CalculateTotalAmountOfUnpaidInvoices(IEnumerable<Domain.Entities.Invoice> invoices)
    {
        var totalAmountOfUnpaidInvoices = invoices.Where(x => x.IsPaid != true)
            .Sum(x => x.TotalAmount);
        return totalAmountOfUnpaidInvoices;
    }

    private TimeSpan CalculateAverageTimeToPay(IEnumerable<Domain.Entities.Invoice> invoices)
    {
        var invoiceList = invoices.ToList();
        if (!invoiceList.Any())
            return TimeSpan.Zero;
        
        var count = 0;
        var totalTimeToPay = TimeSpan.Zero;

        foreach (var invoice in invoiceList)
        {
            var timeToPay = invoice.TimeToPay;
            if (!timeToPay.HasValue) continue;
            totalTimeToPay += timeToPay.Value;
            count++;
        }

        if (count <= 0) return TimeSpan.Zero;

        var averageTimeToPay = TimeSpan.FromHours(Math.Round(totalTimeToPay.TotalSeconds / count));
        return averageTimeToPay;
    }
}