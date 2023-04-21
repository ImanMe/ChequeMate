namespace ChequeMate.Domain.Entities;

public class Invoice : BaseEntity
{
    public string CustomerName { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? PaymentDate { get; set; }
    public bool IsPaid { get; set; }
    public ICollection<ListItem> ListItems { get; set; } = new List<ListItem>();
}