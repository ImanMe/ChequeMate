namespace ChequeMate.Domain.Entities;

public class Invoice : BaseEntity
{
    public string CustomerName { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? PaymentDate { get; set; }
    public bool IsPaid { get; set; }
    public ICollection<ListItem> ListItems { get; set; } = new List<ListItem>();
    public decimal TotalAmount => ListItems.Sum(x => x.TotalPrice);
    public TimeSpan? TimeToPay => IsPaid && PaymentDate.HasValue ? PaymentDate.Value - DueDate : null;

    public void SetAsPaid()
    {
        IsPaid = true;
        PaymentDate = DateTime.Now;
    }
}