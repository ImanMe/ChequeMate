namespace ChequeMate.Domain.Entities;

public class Invoice : BaseEntity
{
    public string CustomerName { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? PaymentDate { get; set; }
    public bool IsPaid { get; set; }
    public ICollection<ListItem> ListItems { get; set; } = new List<ListItem>();

    public decimal CalculateTotalAMount()
    {
        var totalAmount = ListItems.Sum(x => x.TotalPrice);
        return totalAmount;
    }

    // Time taken for this invoice to be paid
    public TimeSpan? CalculateTimeToPay()
    {
        return IsPaid && PaymentDate.HasValue ? PaymentDate.Value - DueDate : null;
    }
}