namespace ChequeMate.API.DTOs;

public class InvoiceVm
{
    public int Id { get; set; }
    public string InvoiceDate { get; set; }
    public string CustomerName { get; set; }
    public string DueDate { get; set; }
    public string PaymentDate { get; set; }
    public bool IsPaid { get; set; }
    public decimal TotalAmount { get; set; }
    public IList<ListItemVm> ListItems { get; set; } = new List<ListItemVm>();
}