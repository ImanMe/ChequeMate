using ChequeMate.Domain.Contracts;
using ChequeMate.Persistence.Contracts;

namespace ChequeMate.Persistence;

public class InvoiceUnitOfWork : UnitOfWork<InvoiceContext>, IInvoiceUnitOfWork
{
    public InvoiceUnitOfWork(InvoiceContext dbContext, IInvoiceRepository invoiceRepository)
        : base(dbContext)
    {
        InvoiceRepository = invoiceRepository;
    }

    public IInvoiceRepository InvoiceRepository { get; }
}