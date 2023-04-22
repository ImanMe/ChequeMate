namespace ChequeMate.API.DTOs;

public class InvoiceQueryResultVm
{
    public decimal TotalAmountOfUnpaidInvoices { get; set; }
    public TimeSpan AverageTimeOfPayment { get; set; }
    public IList<InvoiceVm> Invoices { get; set; } = new List<InvoiceVm>();
}