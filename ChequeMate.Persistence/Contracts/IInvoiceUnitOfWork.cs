using ChequeMate.Domain.Contracts;

namespace ChequeMate.Persistence.Contracts;

public interface IInvoiceUnitOfWork : IUnitOfWork<InvoiceContext>
{
    IInvoiceRepository InvoiceRepository { get; }
}