using ChequeMate.API.Features.Invoice.Queries.GetInvoices;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChequeMate.API.Controllers;

public class InvoicesController : BaseApiController
{
    private readonly IMediator _mediator;

    public InvoicesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Get(bool? isPaid)
    {
        var getInvoiceQuery = new GetInvoicesQuery(isPaid);

        var invoices = await _mediator.Send(getInvoiceQuery);

        return Ok(invoices);
    }
}