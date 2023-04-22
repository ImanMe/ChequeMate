namespace ChequeMate.Domain.Entities;

public class Invoice : BaseEntity
{
    public string CustomerName { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? PaymentDate { get; set; }
    public bool IsPaid { get; set; }
    public ICollection<ListItem> ListItems { get; set; } = new List<ListItem>();
    public decimal TotalAmount => ListItems.Sum(x => x.TotalPrice);
    public int? TimeToPayInHours => GetTimeToPay();

    public void SetAsPaid()
    {
        IsPaid = true;
        PaymentDate = DateTime.Now;
    }

    private int? GetTimeToPay()
    {
        if (IsPaid && PaymentDate.HasValue)
        {
            var timeToPay = PaymentDate - CreatedDate;
            if (timeToPay == null) return 0;
            var totalHours = timeToPay.Value.TotalHours;
            return (int)Math.Round(totalHours);
        }

        return null;
    }
}