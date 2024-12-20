﻿using ChequeMate.Domain.Contracts;
using ChequeMate.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChequeMate.Persistence.Repositories;

public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
{
    public InvoiceRepository(InvoiceContext context) : base(context.Set<Invoice>())
    {
    }

    public async Task<IList<Invoice>> GetAllWithListItemsByDueDate(bool? isPaid = null)
    {
        var query = DbSet.AsQueryable();

        if (isPaid != null)
            query = DbSet.Where(x => x.IsPaid == isPaid);
        
        return await query.OrderByDescending(x => x.DueDate)
            .Include(x => x.ListItems)
            .ToListAsync();
    }

    public async Task<Invoice> GetByIdWithListItems(int id)
    {
        var invoice = await DbSet.Include(x => x.ListItems)
            .SingleOrDefaultAsync(x => x.Id == id);
        return invoice;
    }
}