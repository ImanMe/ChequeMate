using ChequeMate.API.Features.Invoice.Commands.CreateInvoice;
using ChequeMate.API.Features.Invoice.Commands.MarkAsPaid;
using ChequeMate.API.Features.Invoice.Queries.GetInvoice;
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

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Get(int id)
    {
        var getInvoiceQuery = new GetInvoiceQuery(id);

        var invoices = await _mediator.Send(getInvoiceQuery);

        if (invoices == null) return BadRequest($"No invoice with Id:{id} exists");

        return Ok(invoices);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Post([FromBody] CreateInvoiceCommand request)
    {
        var response = await _mediator.Send(request);

        if (response.Success) return CreatedAtAction("Get", new { id = response.Invoice.Id }, response);

        return BadRequest(response);
    }

    [HttpPatch("{id}/mark-as-paid", Name = "MarkInvoiceAsPaid")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> MarkInvoiceAsPaid(int id)
    {
        var markAsPaidCommand = new MarkAsPaidCommand(id);

        var response = await _mediator.Send(markAsPaidCommand);

        if (response.Success) return NoContent();

        return BadRequest(response.Message);
    }

}