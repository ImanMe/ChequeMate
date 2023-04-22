namespace ChequeMate.API.DTOs;

public class InvoiceQueryResultVm
{
    public decimal TotalAmountOfUnpaidInvoices { get; set; }
    public double? AverageTimeOfPaymentInHours { get; set; }
    public IList<InvoiceVm> Invoices { get; set; } = new List<InvoiceVm>();
}