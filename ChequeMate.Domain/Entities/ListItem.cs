namespace ChequeMate.Domain.Entities;

public class ListItem : BaseEntity
{
    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}