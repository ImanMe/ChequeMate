using ChequeMate.Domain.Entities;

namespace ChequeMate.Domain.Contracts;

public interface IInvoiceRepository : IRepository<Invoice>
{
    Task<IList<Invoice>> GetAllWithListItemsByDueDate(bool? isPaid);
    Task<Invoice> GetByIdWithListItems(int id);
}