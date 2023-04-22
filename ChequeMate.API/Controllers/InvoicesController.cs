using ChequeMate.Persistence.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ChequeMate.API.Controllers;

public class InvoicesController : BaseApiController
{
    private readonly IInvoiceUnitOfWork _invoiceUnitOfWork;

    public InvoicesController(IInvoiceUnitOfWork invoiceUnitOfWork)
    {
        _invoiceUnitOfWork = invoiceUnitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var invoices = await _invoiceUnitOfWork.InvoiceRepository.GetAllWithListItemsByDueDate(null);

        return Ok(invoices);
    }
}